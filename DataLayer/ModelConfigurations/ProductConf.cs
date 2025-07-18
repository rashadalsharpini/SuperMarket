using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ModelConfigurations;

public class ProductConf:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasMany(p => p.ProductOrders)
            .WithOne(po => po.Product)
            .HasForeignKey(po => po.ProductId);

        builder.HasMany(p => p.ProductProducers)
            .WithOne(pp => pp.Product)
            .HasForeignKey(pp => pp.ProductId);

        builder.HasMany(p => p.ProductPurchaseReceipts)
            .WithOne(ppr => ppr.Product)
            .HasForeignKey(ppr => ppr.ProductId);
    }
}