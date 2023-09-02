namespace BikeInventoryManagement.Models
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? SqFtSize { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
