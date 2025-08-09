using DataLayer.Entities;
using DataLayer.Enums;
using DataLayer.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.interfaces;

namespace ServiceLayer.services;

public class ExpensesService(IUnitOfWork uow) : IExpensesService
{
    private readonly IGenericRepo<Expenses, int> repo = uow.GetGenericRepo<Expenses, int>();

    public async Task<Expenses> GetExpensesById(int id)
    {
        return await repo.GetByIdAsync(id) ?? throw new NullReferenceException();
    }

    public async Task<(decimal sum, IEnumerable<Expenses>)> GetAllExpenses()
    {
        var expenses = await repo.GetAllAsync() ?? throw new NullReferenceException();
        var sum = await repo.Query().SumAsync(e => e.Amount);
        return (sum, expenses);
    }

    public async Task<Expenses?> CreateAsync(decimal amount, DateOnly date, string description, KindOfExpenses koe)
    {
        var entity = new Expenses(amount, date, description, koe);
        await repo.AddAsync(entity);
        await uow.SaveChangesAsync();
        return entity;
    }

    public async Task<Expenses> UpdateAsync(int id, decimal amount, DateOnly date, string description,
        KindOfExpenses koe)
    {
        var entity = await repo.GetByIdAsync(id) ?? throw new NullReferenceException();

        entity.Amount = amount;
        entity.Date = date;
        entity.Description = description;
        entity.Koe = koe;

        repo.Update(entity);
        await uow.SaveChangesAsync();
        return entity;
    }

    public async Task<Expenses> RemoveAsync(int id)
    {
        var entity = await repo.GetByIdAsync(id) ?? throw new NullReferenceException();
        repo.Remove(entity);
        await uow.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<Expenses>> GetAllExpensesFromToKind(DateOnly from, DateOnly to, KindOfExpenses koe)
    {
        return await repo.Query().Where(e => e.Date >= from && e.Date <= to && e.Koe == koe).ToListAsync();
    }
}