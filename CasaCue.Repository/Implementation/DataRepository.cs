using CasaCue.Data.Contract;
using CasaCue.Data.Models;
using CasaCue.Repository.Contract;
using System.Linq.Expressions;

namespace CasaCue.Repository.Implementation
{
    public class DataRepository<TModel> : IDataRepository<TModel>
        where TModel : BaseModel
    {
        private readonly IDataContext dataContext;

        public DataRepository(IDataContext dataContext)
        {
            this.dataContext = dataContext; 
        }

        public IQueryable<TModel> GetAll()
        {
            return dataContext.GetAll<TModel>();
        }

        public Task<TModel?> GetByPredicateAsync(Expression<Func<TModel, bool>> predicate)
        {
            return dataContext.GetByPredicateAsync<TModel>(predicate);
        }

        public void Insert(TModel model)
        {
            dataContext.Insert(model);  
        }

        public void Update(TModel model)
        {
            dataContext.UpdateOne(model);
        }

        public void Delete(TModel model)
        {
            dataContext.Delete(model);
        }

         
    }
}
