using System.Collections.Generic;

namespace WareHouse.Application.Departments.Models;

public class DepartmentModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> Products { get; set; }
    public List<string> Workers { get; set; }
}
