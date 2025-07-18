using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ModelConfigurations;

public class PurchaseReceiptConf:IEntityTypeConfiguration<PurchaseReceipt>
{
    public void Configure(EntityTypeBuilder<PurchaseReceipt> builder)
    {
        builder.HasMany(p => p.ProductPurchaseReceipts)
            .WithOne(ppr => ppr.PurchaseReceipt)
            .HasForeignKey(ppr => ppr.PurchaseReceiptId);
    }
}