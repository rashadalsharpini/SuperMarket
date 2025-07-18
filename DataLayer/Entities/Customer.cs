namespace DataLayer.Entities;

public class Customer: BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public decimal TotalRemaining { get; set; }
    public decimal TotalPaid { get; set; }
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
}