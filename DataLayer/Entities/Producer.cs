namespace DataLayer.Entities;

public class Producer:BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public decimal AmountOwed { get; set; }
    public ICollection<ProductProducer> ProductProducers { get; set; } = null!;
}