using System.Collections.Generic;

namespace WareHouse.Api.Dtos
{
    public class WorkerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Departments { get; set; }
    }
}
