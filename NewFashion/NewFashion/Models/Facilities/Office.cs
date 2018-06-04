using System.ComponentModel.DataAnnotations;

namespace NewFashion.Models.Facilities
{
    public class Office
    {
        public int OfficeID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string City { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Address { get; set; }
    }
}