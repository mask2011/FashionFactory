using NewFashion.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace NewFashion.ViewModels
{
    public class SalesFormViewModel
    {
        [Required]
        public int InvoiceId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string ProductId { get; set; }

        [Required]
        public ProductType ProductType { get; set; }
    }
}