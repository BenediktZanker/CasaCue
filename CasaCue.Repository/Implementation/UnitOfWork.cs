using CasaCue.Data.Contract;
using CasaCue.Repository.Contract;

namespace CasaCue.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataContext dataContext;

        public UnitOfWork(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public bool Commit()
        {
            return dataContext.Commit();
        }

        public Task<bool> CommitAsync()
        {
            return dataContext.CommitAsync();
        }
    }
}
