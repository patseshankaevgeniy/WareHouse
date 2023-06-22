using System.Collections.Generic;

namespace WareHouse.Domain.Entities;

public class Worker : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ICollection<Department> Departments { get; set; } = default!;
}
