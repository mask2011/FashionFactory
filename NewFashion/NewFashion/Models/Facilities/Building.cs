using NewFashion.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace NewFashion.Models.Facilities
{
    public class Building
    {
        public int BuildingId { get; set; }

        [Required]
        public BuildingType BuildingType { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string City { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Address { get; set; }
    }
}