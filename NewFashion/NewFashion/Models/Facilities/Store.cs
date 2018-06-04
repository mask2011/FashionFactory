using System.ComponentModel.DataAnnotations;

namespace NewFashion.Models.Facilities
{
    public class Store
    {
        public int StoreID { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Product Capacity must be numeric!")]
        [Display(Name = "Product Capacity")]
        public int ProductCapacity { get; set; }
    }
}