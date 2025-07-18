namespace DataLayer.Entities;

public class PurchaseReceipt: BaseEntity<int>
{
    public DateTime Date { get; set; }
    public decimal Total { get; set; }
    public decimal TotalOwed { get; set; }
    public decimal TotalPaid { get; set; }
    public int ProducerId { get; set; }
    public Producer Producer { get; set; } = null!;
    public ICollection<ProductPurchaseReceipt> ProductPurchaseReceipts { get; set; } = null!;
}