using Microsoft.EntityFrameworkCore;
using SFSAdv.Domain.Aggregates.OrderAggregate.Entities;
using SFSAdv.Domain.Aggregates.ProductAggregate.Entities;
using SFSAdv.Domain.Aggregates.UserAggregate.Entities;

namespace SFSAdv.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Title)
            .IsUnique();

        modelBuilder.Entity<Product>()
            .Property(p => p.Title)
            .HasMaxLength(40);

        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,0)");

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Product);

        modelBuilder.Entity<Order>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,0)");

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Buyer)
            .WithMany(u => u.Orders);

        modelBuilder.Entity<User>().HasData(User.Create(Guid.NewGuid(), "User 1"),
                                            User.Create(Guid.NewGuid(), "User 2"),
                                            User.Create(Guid.NewGuid(), "User 3"),
                                            User.Create(Guid.NewGuid(), "User 4"),
                                            User.Create(Guid.NewGuid(), "User 5"));
    }
}
