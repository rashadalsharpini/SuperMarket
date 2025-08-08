using DataLayer.Enums;

namespace DataLayer.Entities;

public class Expenses : BaseEntity<int>
{
    public Expenses()
    {
    }

    public Expenses(decimal amount, DateOnly date, string description, KindOfExpenses koe)
    {
        Amount = amount;
        Date = date;
        Description = description;
        Koe = koe;
    }

    public decimal Amount { get; set; }
    public DateOnly Date { get; set; }
    public KindOfExpenses Koe { get; set; }
}