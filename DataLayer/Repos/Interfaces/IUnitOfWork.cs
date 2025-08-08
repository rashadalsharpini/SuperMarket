using DataLayer.Entities;

namespace DataLayer.Repos.Interfaces;

public interface IUnitOfWork
{
    IGenericRepo<TEntity,TKey> GetGenericRepo<TEntity, TKey>() where TEntity:BaseEntity<TKey>;
    Task<int> SaveChangesAsync();
}