using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using TechnoShopApi.Inventory.Domain.Model.Aggregates;
using TechnoShopApi.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace TechnoShopApi.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductContainer> Containers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            throw new InvalidOperationException("No database provider has been configured for this context.");
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().ToTable("products");
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Product>().Property(p => p.Description).IsRequired().HasMaxLength(500);
        modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.Quantity).IsRequired();
        
        modelBuilder.Entity<ProductContainer>().ToTable("containers");
        modelBuilder.Entity<ProductContainer>().HasKey(c => c.Id);
        modelBuilder.Entity<ProductContainer>().Property(c => c.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<ProductContainer>().Property(c => c.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<ProductContainer>().Property(c => c.Capacity).IsRequired();
        modelBuilder.Entity<ProductContainer>().Property(c => c.CurrentCapacity).IsRequired();
        modelBuilder.Entity<ProductContainer>().HasOne(c => c.Product).WithMany(p => p.Containers).HasForeignKey(c => c.ProductId);
        
        modelBuilder.UseSnakeCaseWithPluralizedTableNamingConvention();
        
        
    }
}