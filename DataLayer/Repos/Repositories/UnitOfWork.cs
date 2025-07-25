using DataLayer.DbContexts;
using DataLayer.Entities;
using DataLayer.Repos.Interfaces;

namespace DataLayer.Repos.Repositories;

public class UnitOfWork(SuperMarketDbContext db) : IUnitOfWork
{
    private readonly Dictionary<string, object> _myRepo = [];

    public IGenericRepo<TEntity, TKey> GetGenericRepo<TEntity, TKey>() where TEntity : BaseEntity<TKey>
    {
        var typeName = typeof(TEntity).Name;
        if (_myRepo.TryGetValue(typeName, out object? value))
            return (IGenericRepo<TEntity, TKey>)value;
        var repo = new GenericRepo<TEntity, TKey>(db);
        _myRepo[typeName] = repo;
        return repo;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await db.SaveChangesAsync();
    }
}