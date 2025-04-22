namespace BuildingCore.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task BeginTranSactionAsync();
        Task CommitTransactionAsync();

        void RollBack();
    }
}
