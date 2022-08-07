using DesignPatternsInCSharp.Others.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPatternsInCSharp.Others.Repository.Data;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<Product>()
            .Property(e => e.UnitPrice)
            .HasPrecision(19, 4);

        _ = modelBuilder.Entity<Category>()
            .Property(e => e.Description);
    }
}
