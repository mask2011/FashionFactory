using System.ComponentModel.DataAnnotations;

namespace NewFashion.Models.Enums
{
    public enum ProductType
    {
        [Display(Name = "T-Shirt")]
        T_Shirt = 0,
        Trousers = 1
    }
}