using Microsoft.AspNetCore.Identity;
using static BuildingCore.Common.Constants;

namespace BuildingCore.Data.SeedData
{
    public class SeedData
    {
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {

            foreach (var role in RoleConstants.AllRoles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
