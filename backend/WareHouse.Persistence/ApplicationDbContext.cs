using Microsoft.EntityFrameworkCore;
using WareHouse.Application.Common.Interfaces;
using WareHouse.Domain.Entities;

namespace WareHouse.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Worker> Workers { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
