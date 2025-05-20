using BuildingCore.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BuildingCore.Data;
public interface IApplicationDbContext
{
    DbSet<CustomerModel> Customers { get; }
    DbSet<User> Users { get; }
    DbSet<DoctorInfo> Doctors { get; }
    DbSet<PatientInfo> Patients { get; }
    DbSet<IdentityRole<int>> Roles { get; }
    DbSet<IdentityUserRole<int>> UserRoles { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
