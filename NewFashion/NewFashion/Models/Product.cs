using NewFashion.Models.Enums;

namespace NewFashion.Models
{
    public class Product
    {
        public string ProductId { get; set; }

        public ProductType Type { get; set; }

        public Gender Gender { get; set; }

        public Size Size { get; set; }

        public Color Color { get; set; }

        public decimal Price { get; set; }

        public int WarehouseQuantity { get; set; }

        public int StoreQuantity { get; set; }
    }
}