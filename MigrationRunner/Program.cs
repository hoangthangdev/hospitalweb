using BuildingCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../HospitalWebAPI"))
    .AddJsonFile("appsettings.json");

        var configuration = builder.Build();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var services = new ServiceCollection();
        services.AddDbContext<HospitalDbContext>(options =>
            options.UseSqlServer(connectionString));

        var serviceProvider = services.BuildServiceProvider();

        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<HospitalDbContext>();

        Console.WriteLine("Applying Migrations...");
        context.Database.Migrate();
        Console.WriteLine("Done.");
    }
}