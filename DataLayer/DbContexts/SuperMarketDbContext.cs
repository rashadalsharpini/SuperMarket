using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DbContexts;

public class SuperMarketDbContext:DbContext
{
    public SuperMarketDbContext(DbContextOptions<SuperMarketDbContext> options):base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
    }
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductOrder> ProductOrders { get; set; } = null!;
    public DbSet<ProductProducer> ProductProducers { get; set; } = null!;
    public DbSet<ProductPurchaseReceipt> ProductPurchaseReceipts { get; set; } = null!;
    public DbSet<Producer> Producers { get; set; } = null!;
    public DbSet<PurchaseReceipt> PurchaseReceipts { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Expenses>  Expenses { get; set; } = null!;
}