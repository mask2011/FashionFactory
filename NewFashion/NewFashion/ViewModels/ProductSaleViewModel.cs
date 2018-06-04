using NewFashion.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace NewFashion.ViewModels
{
    public class ProductSaleViewModel
    {
        public int Quantity { get; set; }
        public string ProductId { get; set; }
        public ProductType Type { get; set; }
        public Gender Gender { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal TotalPrice
        {
            get
            {
                return Quantity * Price;
            }
        }
    }
}