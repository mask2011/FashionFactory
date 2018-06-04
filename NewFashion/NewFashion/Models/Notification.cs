using System;
using System.ComponentModel.DataAnnotations;

namespace NewFashion.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        [Required]
        public SupplierOffer SupplierOffer { get; set; }

        protected Notification()
        {
        }

        private Notification(SupplierOffer supplierOffer)
        {
            if (supplierOffer == null)
            {
                throw new ArgumentNullException();
            }

            SupplierOffer = supplierOffer;
            DateTime = DateTime.Now;
        }

        public static Notification OfferCreated(SupplierOffer supplierOffer)//factoty method
        {
            return new Notification(supplierOffer);
        }
    }
}