using System.Collections.Generic;

namespace WareHouse.Api.Dtos.Depatments
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Products { get; set; }
        public List<string> Workers { get; set; }
    }
}
