using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewFashion.Models
{
    public class Buying
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Sale")]
        public int SaleId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Product")]
        public string ProductId { get; set; }

        public virtual Sale Sale { get; set; }
        public virtual Product Product { get; set; }
    }
}