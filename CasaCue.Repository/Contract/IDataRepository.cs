using CasaCue.Data.Models;
using System.Linq.Expressions;

namespace CasaCue.Repository.Contract
{
    public interface IDataRepository<TModel>
        where TModel : BaseModel
    {

        IQueryable<TModel> GetAll();

        Task<TModel?> GetByPredicateAsync(Expression<Func<TModel, bool>> predicate);

        void Insert(TModel model);

        void Update(TModel model);

        void Delete(TModel model);
    }
}
