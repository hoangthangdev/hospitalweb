using BuildingCore.Data.Identity;
using BuildingCore.Data.Model;
using BuildingCore.Extentions;
using BuildingCore.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Security.Claims;

namespace BuildingCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext, IUnitOfWork
    {
        private IDbContextTransaction? _currentTransaction;
        private readonly ClaimsPrincipal claimsPrincipal;

        public DbSet<CustomerModel> Customers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ClaimsPrincipal claimsPrincipal)
            : base(options)
        {
            this.claimsPrincipal = claimsPrincipal;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            builder.ConfigureConventions();
        }

        public IDbContextTransaction? GetCurrentTransaction() => _currentTransaction;

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            BeforeSaveChanges();
            return await base.SaveChangesAsync(cancellationToken);
        }

        public async Task BeginTranSactionAsync()
        {
            if (_currentTransaction == null)
            {
                _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
            }
        }

        public async Task CommitTransactionAsync()
        {
            if (_currentTransaction is null)
            {
                throw new ArgumentNullException(nameof(this._currentTransaction));
            }

            try
            {
                await SaveChangesAsync();
                await _currentTransaction.CommitAsync();
            }
            catch
            {
                RollBack();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.DisposeAsync();
                    _currentTransaction = null;
                }
            }
        }

        public void RollBack()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        private void BeforeSaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entry.Entity is IEntity added)
                        {
                            added.CreatedTime = DateTime.UtcNow;
                        }

                        if (entry.Entity is IHasTrace hasTrace)
                        {
                            hasTrace.CreatedBy = this.claimsPrincipal.GetUserId();
                            hasTrace.CreateByName = this.claimsPrincipal.GetUserName();
                        }

                        break;
                    case EntityState.Modified:
                        if (entry.Entity is IEntity modified)
                        {
                            modified.ModifyTime = DateTime.UtcNow;
                        }

                        if (entry.Entity is IHasTrace trace)
                        {
                            trace.ModifiedBy = claimsPrincipal.GetUserId();
                            trace.ModifyByName = claimsPrincipal.GetUserName();
                        }

                        break;
                    case EntityState.Deleted:

                        if (entry.Entity is IHasIsDeleted hasIsDeleted)
                        {
                            hasIsDeleted.IsDeleted = true;
                            entry.State = EntityState.Modified;
                        }

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
