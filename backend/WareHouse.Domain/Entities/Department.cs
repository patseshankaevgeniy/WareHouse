using System.Collections.Generic;

namespace WareHouse.Domain.Entities;

public class Department : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; } = default!;
    public ICollection<Worker> Workers { get; set; } = default!;

}
