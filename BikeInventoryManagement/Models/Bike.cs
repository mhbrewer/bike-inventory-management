using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeInventoryManagement.Models
{
    public class Bike
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        [Display(Name = "Frame Size (cm)")]
        public int FrameSizeCm { get; set; }
        [Display(Name = "Bike Type")]
        public BikeType? BikeType { get; set; }
        [Display(Name = "Is Boxed?")]
        public bool IsBoxed { get; set; }
        [Display(Name = "Serial Number")]
        public string? SerialNumber { get; set; }
        public string? Condition { get; set; }
        public string? Notes { get; set; }
        [Display(Name = "Storage Location")]
        public Location? StorageLocation { get; set; }
    }
}
