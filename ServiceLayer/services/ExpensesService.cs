using DataLayer.Entities;
using DataLayer.Enums;
using DataLayer.Repos.Interfaces;
using ServiceLayer.interfaces;

namespace ServiceLayer.services;

public class ExpensesService(IUnitOfWork uow) : IExpensesService
{
    private readonly IGenericRepo<Expenses, int> repo = uow.GetGenericRepo<Expenses, int>();

    public async Task<Expenses> GetExpensesById(int id)
    {
        return await repo.GetByIdAsync(id) ?? throw new NullReferenceException();
    }

    public async Task<IEnumerable<Expenses>> GetAllExpenses()
    {
        return await repo.GetAllAsync() ?? throw new NullReferenceException();
    }

    public async Task<Expenses?> CreateAsync(decimal amount, DateOnly date, string description, KindOfExpenses koe)
    {
        var entity = new Expenses(amount, date, description, koe);
        await repo.AddAsync(entity);

        var isCreated = await repo.GetByIdAsync(entity.Id);
        if (isCreated is null)
            throw new NullReferenceException();
        return entity;
    }

    public async Task<Expenses> UpdateAsync(int id, decimal amount, DateOnly date, string description, KindOfExpenses koe)
    {
        var entity = await repo.GetByIdAsync(id) ?? throw new NullReferenceException();

        entity.Amount = amount;
        entity.Date = date;
        entity.Description = description;
        entity.Koe = koe;

        repo.Update(entity);
        return entity;
    }

    public async Task<Expenses> RemoveAsync(int id)
    {
        var entity = await repo.GetByIdAsync(id) ?? throw new NullReferenceException();
        repo.Remove(entity);
        return entity;
    }

    public async Task<Expenses> SearchAsync(int id)
    {
        return await GetExpensesById(id);
    }
}