using DataLayer.Enums;

namespace DataLayer.Entities;

public class Expenses:BaseEntity<int>
{
    public decimal Amount { get; set; }
    public KindOfExpenses Koe { get; set; }
}