using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WareHouse.Domain.Entities;

namespace WareHouse.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Worker> Workers { get; set; }
    DbSet<Department> Departments { get; set; }
    DbSet<Product> Products { get; set; }

    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}
