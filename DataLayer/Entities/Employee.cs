namespace DataLayer.Entities;

public class Employee: BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public decimal Salary { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
}