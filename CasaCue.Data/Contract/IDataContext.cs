using System.Linq.Expressions;

namespace CasaCue.Data.Contract
{
    /// <summary>
    /// This is a isolated context which can work with any framework. Decoupling.
    /// </summary>
    public interface IDataContext
    {
        IQueryable<T> GetAll<T>()
            where T : class;

        /// <summary>
        /// Get the data from database based on condition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns>It can return data if present</returns>
        T? GetByPredicate<T>(Expression<Func<T, bool>> predicate) 
            where T : class;

        /// <summary>
        /// Get the data from database based on condition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns>It can return data if present</returns>
        Task<T?> GetByPredicateAsync<T>(Expression<Func<T, bool>> predicate)
            where T : class;

        /// <summary>
        /// Insert a record but do not save it as it should be managed by transaction
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Insert<T>(T entity)
            where T : class;

        /// <summary>
        /// Update a record but do not save it as it should be managed by transaction
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void UpdateOne<T>(T entity)
            where T : class;

        /// <summary>
        /// Delete a record but do not save it as it should be managed by transaction
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Delete<T>(T entity)
            where T : class;

        /// <summary>
        /// Save the data in database using the transaction
        /// </summary>
        /// <returns></returns>
        bool Commit();

        /// <summary>
        /// Save the data in database using the transaction
        /// </summary>
        /// <returns></returns>
        Task<bool> CommitAsync();
    }
}
