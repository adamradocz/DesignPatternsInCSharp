using DesignPatternsInCSharp.Others.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPatternsInCSharp.Others.Repository;

public class TrainingDbContext : DbContext
{
    public TrainingDbContext(DbContextOptions<TrainingDbContext> options) : base(options)
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

        _ = modelBuilder.Entity<Category>()
            .Property(e => e.Picture);
    }
}
