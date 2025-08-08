using DataLayer.Entities;
using DataLayer.Enums;

namespace ServiceLayer.interfaces;

public interface IExpensesService
{
    Task<Expenses> GetExpensesById(int id);
    Task<IEnumerable<Expenses>> GetAllExpenses();
    Task<Expenses?> CreateAsync(decimal amount, DateOnly date, string description, KindOfExpenses koe);
    Task<Expenses> UpdateAsync(int id, decimal amount, DateOnly date, string description, KindOfExpenses koe);
    Task<Expenses> RemoveAsync(int id);
    Task<Expenses> SearchAsync(int id);
}