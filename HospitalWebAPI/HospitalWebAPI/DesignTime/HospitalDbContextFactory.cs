using BuildingCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HospitalWebAPI.DesignTime;

public class HospitalDbContextFactory : IDesignTimeDbContextFactory<HospitalDbContext>
{
    public HospitalDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=HospitalDB;User Id=sa;Password=your_password;");

        return new HospitalDbContext(optionsBuilder.Options);
    }
}
