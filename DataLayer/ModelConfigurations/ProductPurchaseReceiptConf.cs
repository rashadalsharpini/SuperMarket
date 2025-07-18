using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ModelConfigurations;

public class ProductPurchaseReceiptConf:IEntityTypeConfiguration<ProductPurchaseReceipt>
{
    public void Configure(EntityTypeBuilder<ProductPurchaseReceipt> builder)
    {
        builder.HasKey(pp => new { pp.ProductId, pp.PurchaseReceiptId });
        
        builder.HasOne(po => po.Product)
            .WithMany(p => p.ProductPurchaseReceipts)
            .HasForeignKey(po => po.ProductId);

        builder.HasOne(po => po.PurchaseReceipt)
            .WithMany(o => o.ProductPurchaseReceipts)
            .HasForeignKey(po => po.PurchaseReceiptId);
    }
}