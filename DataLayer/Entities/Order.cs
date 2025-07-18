namespace DataLayer.Entities;

public class Order: BaseEntity<int>
{
    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
    public decimal Paid { get; set; }
    public decimal Remained { get; set; }
    public decimal Total { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
    public ICollection<ProductOrder> ProductOrders { get; set; } = null!;
}