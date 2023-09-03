using System.ComponentModel.DataAnnotations;

namespace BikeInventoryManagement.Models
{
    public class BikePhoto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        [Display(Name = "File Name")]
        public string? FileName { get; set; }
        public Bike Bike { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
