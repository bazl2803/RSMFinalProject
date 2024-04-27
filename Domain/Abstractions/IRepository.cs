namespace Domain.Abstractions
{
    using System.Linq.Expressions;

    public interface IRepository<TEntity, in TId>
        where TEntity : Entity<TId>
        where TId : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TId id);
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}