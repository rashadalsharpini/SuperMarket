using DataLayer.DbContexts;
using DataLayer.Entities;
using DataLayer.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repos.Repositories;

public class GenericRepo<TEntity, TKey>(SuperMarketDbContext db):IGenericRepo<TEntity, TKey>where TEntity:BaseEntity<TKey>
{
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await db.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        return await db.Set<TEntity>().FindAsync(id);
    }

    public async Task AddAsync(TEntity entity)
    {
        await db.Set<TEntity>().AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        db.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        db.Set<TEntity>().Remove(entity);
    }
}