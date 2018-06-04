using NewFashion.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace NewFashion.ViewModels
{
    public enum FemaleSizes
    {
        XSmall,
        Small,
        Medium,
        Large,
        XL
    }

    public enum MaleSizes
    {
        Small,
        Medium,
        Large,
        XL,
        XXL
    }

    public class FactoryProduction
    {
        [Required]
        public int Quantity { get; set; }

        [Required]
        public ProductType Type { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Size Size { get; set; }

        [Required]
        public Color Color { get; set; }

        public string Message { get; set; }

    }
}