using CasaCue.Data.Contract;
using CasaCue.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CasaCue.Data.Implementation
{
    public class EfDataContext(DbContextOptions dbContextOptions)
        : DbContext(dbContextOptions), IDataContext
    {
        public bool Commit()
        {
            return SaveChanges() > 0;
        }

        public async Task<bool> CommitAsync()
        {
            return (await SaveChangesAsync() > 0);
        }

        public void Delete<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
            Entry(entity).State = EntityState.Deleted;
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return Set<T>();
        }

        public T? GetByPredicate<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return GetAll<T>().FirstOrDefault(predicate);
        }

        public Task<T?> GetByPredicateAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return GetAll<T>().FirstOrDefaultAsync(predicate);
        }

        public void Insert<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
            Entry(entity).State = EntityState.Added;
        }

        public void UpdateOne<T>(T entity) where T : class
        {
            Entry(entity).State = EntityState.Modified;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Guest>()
                .HasKey(s => s.Id)
                ;

        }
    }
}
