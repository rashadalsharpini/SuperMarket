namespace DataLayer.Entities;

public class Product: BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal BuyPrice { get; set; }
    public decimal Profit { get; set; }
    public decimal AllowedDiscount { get; set; }
    public decimal SellPrice => BuyPrice + Profit;
    public ICollection<ProductOrder>  ProductOrders { get; set; } = null!;
    public ICollection<ProductProducer> ProductProducers { get; set; } = null!;
    public ICollection<ProductPurchaseReceipt> ProductPurchaseReceipts { get; set; } = null!;
}