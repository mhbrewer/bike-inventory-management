using System.ComponentModel.DataAnnotations;

namespace BikeInventoryManagement.Models
{
    public interface IPhoto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        [Display(Name = "File Name")]
        public string FileName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
