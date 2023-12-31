﻿using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Listable?")]
        public bool IsListable { get; set; }
        [Display(Name = "List Price")]
        public double? ListPrice { get; set; }
        public double? Cost { get; set; }
        [Display(Name = "Inventory Count")]
        public int InventoryCount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
