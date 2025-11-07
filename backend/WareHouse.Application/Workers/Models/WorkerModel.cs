using System.Collections.Generic;

namespace WareHouse.Application.Workers.Models;

public class WorkerModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<string> Departments { get; set; }
}
