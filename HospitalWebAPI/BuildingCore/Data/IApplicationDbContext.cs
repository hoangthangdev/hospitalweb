using BuildingCore.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BuildingCore.Data;
public interface IApplicationDbContext
{
    DbSet<CustomerModel> Customers { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
