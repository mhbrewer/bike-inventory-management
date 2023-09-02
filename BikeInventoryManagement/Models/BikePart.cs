using System.ComponentModel.DataAnnotations;

namespace BikeInventoryManagement.Models
{
    public class BikePart
    {
        public int ID { get; set; }
        [Display(Name = "Name")]
        public string PartName { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        [Display(Name = "Is Boxed?")]
        public bool IsBoxed { get; set; }
        public string? Notes { get; set; }
        [Display(Name = "Storage Location")]
        public Location? StorageLocation { get; set; }
        [Display(Name = "Listable?")]
        public bool IsListable { get; set; }
        [Display(Name = "List Price")]
        public double? ListPrice { get; set; }
        [Display(Name = "Cost Per Part")]
        public double? Cost { get; set; }
        [Display(Name = "Inventory Count")]
        public int InventoryCount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
