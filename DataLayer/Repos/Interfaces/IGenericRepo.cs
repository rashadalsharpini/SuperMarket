using DataLayer.Entities;

namespace DataLayer.Repos.Interfaces;

public interface IGenericRepo<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    IQueryable<TEntity> Query();
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(TKey id);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}