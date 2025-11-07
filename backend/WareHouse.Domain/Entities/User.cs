namespace WareHouse.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}
