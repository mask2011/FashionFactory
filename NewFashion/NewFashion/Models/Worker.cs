using System.ComponentModel.DataAnnotations;

namespace NewFashion.Models
{
    public class Worker
    {
        public int WorkerID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        public int? FactoryID { get; set; }

        public int? WarehouseID { get; set; }
    }
}