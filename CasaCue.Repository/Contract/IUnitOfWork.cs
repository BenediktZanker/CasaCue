namespace CasaCue.Repository.Contract
{
    public interface IUnitOfWork
    {
        bool Commit();

        Task<bool> CommitAsync();
    }
}
