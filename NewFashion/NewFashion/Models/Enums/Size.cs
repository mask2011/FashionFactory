using System.ComponentModel.DataAnnotations;

namespace NewFashion.Models.Enums
{
    public enum Size
    {
        XSmall,
        Small,
        Medium,
        Large,

        [Display(Name = "XLarge")]
        XL,

        [Display(Name = "XXLarge")]
        XXL
    }
}