using DataLayer.DbContexts;
using DataLayer.Entities;
using DataLayer.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repos.Repositories;

public class GenericRepo<TEntity, TKey>:IGenericRepo<TEntity, TKey>where TEntity:BaseEntity<TKey>
{
    private readonly DbSet<TEntity> dbSet;

    public GenericRepo(SuperMarketDbContext db)
    {
        dbSet = db.Set<TEntity>();
    }
    public IQueryable<TEntity> Query()
    {
        return dbSet.AsQueryable();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task AddAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        dbSet.Update(entity);
    }

    public void Remove(TEntity entity)
    {
        dbSet.Remove(entity);
    }
}