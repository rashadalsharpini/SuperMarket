using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ModelConfigurations;

public class OrderConf:IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasMany(o => o.ProductOrders)
            .WithOne(po => po.Order)
            .HasForeignKey(po => po.OrderId);

        builder.HasOne(o => o.Customer)
            .WithMany()
            .HasForeignKey(o => o.CustomerId);

        builder.HasOne(o => o.Employee)
            .WithMany()
            .HasForeignKey(o => o.EmployeeId);
    }
}