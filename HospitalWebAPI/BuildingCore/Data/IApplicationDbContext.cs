using BuildingCore.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BuildingCore.Data;
public interface IApplicationDbContext
{
    //DbSet<CustomerModel> Customers { get; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Patient> Patients { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
