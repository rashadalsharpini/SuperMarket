namespace DataLayer.Entities;

public class ProductProducer
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int ProducerId { get; set; }
    public Producer Producer { get; set; } = null!;
}