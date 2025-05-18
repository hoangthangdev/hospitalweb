using BuildingCore.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BuildingCore.Data;
public interface IApplicationDbContext
{
    DbSet<CustomerModel> Customers { get; }
    DbSet<User> Users { get; }
    DbSet<DoctorInfo> Doctors { get; }
    DbSet<PatientInfo> Patients { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
