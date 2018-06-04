using NewFashion.Models.Enums;

namespace NewFashion.ViewModels
{
    public class FactoryStock
    {
        public string ProductId { get; set; }
        public ProductType Type { get; set; }
        public Gender Gender { get; set; }
        public decimal Price { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }
        public int NumberOfProducts { get; set; }
    }
}