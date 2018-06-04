using System;
using System.Web.Mvc;

namespace NewFashion.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }
        
        public int Quantity { get; set; }

        public DateTime DateTime { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }
    }
}