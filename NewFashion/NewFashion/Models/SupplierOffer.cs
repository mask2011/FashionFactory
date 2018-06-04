using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewFashion.Models
{
    public class SupplierOffer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [RegularExpression("^\\d+(\\.\\d{1,2})?$", ErrorMessage = "The value must be numeric.")]
        public decimal Cloth { get; set; }

        [Required]
        [Display(Name = "Price/Meter")]
        [RegularExpression("^\\d+(\\.\\d{1,2})?$", ErrorMessage = "The value must be numeric.")]
        public decimal PricePerMeter { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "The value must be numeric.")]
        public int Buttons { get; set; }

        [Required]
        [Display(Name = "Price/Button")]
        [RegularExpression("^\\d+(\\.\\d{1,2})?$", ErrorMessage = "The value must be numeric.")]
        public decimal PricePerButton { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "The value must be numeric.")]
        public int Stickers { get; set; }

        [Required]
        [Display(Name = "Price/Sticker")]
        [RegularExpression("^\\d+(\\.\\d{1,2})?$", ErrorMessage = "The value must be numeric.")]
        public decimal PricePerSticker { get; set; }

        [Required]
        [RegularExpression("^\\d+(\\.\\d{1,2})?$", ErrorMessage = "The value must be numeric.")]
        public decimal Thread { get; set; }

        [Required]
        [Display(Name = "Price/Thread")]
        [RegularExpression("^\\d+(\\.\\d{1,2})?$", ErrorMessage = "The value must be numeric.")]
        public decimal PricePerThread { get; set; }

        [Required]
        [RegularExpression("^\\d+(\\.\\d{1,2})?$", ErrorMessage = "The value must be numeric.")]
        public decimal Zipper { get; set; }

        [Required]
        [Display(Name = "Price/Zipper")]
        [RegularExpression("^\\d+(\\.\\d{1,2})?$", ErrorMessage = "The value must be numeric.")]
        public decimal PricePerZipper { get; set; }

        [Required]
        public bool IsSelected { get; set; }

        [Required]
        public bool IsCalculated { get; set; }

        [Required]
        public string SupplierID { get; set; }

        public virtual ApplicationUser Supplier { get; set; }

        public void Created(List<ApplicationUser> usersToNotify)
        {
            var notification = Notification.OfferCreated(this);

            foreach (var admin in usersToNotify)
            {
                admin.Notify(notification);
            }
        }
    }
}