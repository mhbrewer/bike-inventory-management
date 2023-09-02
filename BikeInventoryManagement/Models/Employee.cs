using static BikeInventoryManagement.Enums.Permissions;

namespace BikeInventoryManagement.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Permission Permission { get; set; }
    }
}
