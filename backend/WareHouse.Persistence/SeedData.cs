using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Domain.Entities;

namespace WareHouse.Persistence
{
    public static class SeedData
    {
        public static async Task AddDefaultDepartmentsAsync(ApplicationDbContext db)
        {
            if (await db.Departments.AnyAsync())
            {
                return;
            }

            var departments = new List<Department>
            {
                new Department
                {
                    Name = "Pharmacy",

                },
                new Department
                {
                    Name = "Food",
                }
            };

            db.Departments.AddRange(departments);
            await db.SaveChangesAsync();
        }
        public static async Task AddDefaultProductsAsync(ApplicationDbContext db)
        {
            if (await db.Products.AnyAsync())
            {
                return;
            }

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Analgin",
                    DepartmentId = 1
                },
                new Product
                {
                    Name = "Pizza",
                   DepartmentId = 1
                }
            };

            db.Products.AddRange(products);
            await db.SaveChangesAsync();
        }
    }
}
