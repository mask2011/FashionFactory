using System;
using System.Collections.Generic;

namespace NewFashion.ViewModels
{
    public class InvoiceViewModel
    {
        public int InvoiceId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal TotalPrice { get; set; }

        public List<ProductSaleViewModel> ProductSaleViewModels { get; set; }
    }
}