namespace BikeInventoryManagement.Models
{
    public class Bike
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int FrameSizeCm { get; set; }
        public BikeType BikeType { get; set; }
        public bool IsBoxed { get; set; }
        public string? SerialNumber { get; set; }
        public string? Condition { get; set; }
        public string? Notes { get; set; }
        public Location StorageLocation { get; set; }
    }
}
