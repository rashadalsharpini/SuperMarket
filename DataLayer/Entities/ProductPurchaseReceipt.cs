namespace DataLayer.Entities;

public class ProductPurchaseReceipt
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int PurchaseReceiptId { get; set; }
    public PurchaseReceipt PurchaseReceipt { get; set; } = null!;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}