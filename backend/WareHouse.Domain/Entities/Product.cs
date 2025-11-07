namespace WareHouse.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public int DepartmentId { get; set; }
}
