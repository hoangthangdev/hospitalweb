using BuildingCore.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BuildingCore.Data;
public interface IApplicationDbContext
{
    DbSet<CustomerModel> Customers { get; }
    DbSet<User> Users { get; }
    DbSet<Doctor> Doctors { get; }
    DbSet<Patient> Patients { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
