using BuildingCore.Data;
using BuildingCore.Data.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingCore.Extentions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder MigrationBase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            using var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Ensure the correct namespace is used for migration-related methods
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            return app;
        }
    }
}
