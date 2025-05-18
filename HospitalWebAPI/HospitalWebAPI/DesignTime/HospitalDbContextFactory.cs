using BuildingCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HospitalWebAPI.DesignTime;

public class HospitalDbContextFactory : IDesignTimeDbContextFactory<HospitalDbContext>
{
    public HospitalDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
        optionsBuilder.UseSqlServer("Server=127.0.0.1,11433;Database=master;User Id=sa;Password=hospotal123@;Trust Server Certificate=True;");

        return new HospitalDbContext(optionsBuilder.Options);
    }
}
