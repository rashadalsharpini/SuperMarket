using DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DataLayer.Repos.Interfaces;

public interface IUnitOfWork
{
    IGenericRepo<TEntity,TKey> GetGenericRepo<TEntity, TKey>() where TEntity:BaseEntity<TKey>;
    Task<int> SaveChangesAsync();
}