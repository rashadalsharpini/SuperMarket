using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ModelConfigurations;

public class ProductProducerConf:IEntityTypeConfiguration<ProductProducer>
{
    public void Configure(EntityTypeBuilder<ProductProducer> builder)
    {
        builder.HasKey(pp => new { pp.ProductId, pp.ProducerId });
        
        builder.HasOne(po => po.Product)
            .WithMany(p => p.ProductProducers)
            .HasForeignKey(po => po.ProductId);

        builder.HasOne(po => po.Producer)
            .WithMany(o => o.ProductProducers)
            .HasForeignKey(po => po.ProducerId);
    }
}