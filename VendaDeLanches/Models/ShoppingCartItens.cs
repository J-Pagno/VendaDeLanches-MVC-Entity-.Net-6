using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaDeLanches.Models
{
    [Table("ShoppingCartItens")]
    public class ShoppingCartItens
    {
        [Key]
        public string ShoppingCartId { get; set; }

        [StringLength(200)]
        public int ShoppingCartItemId { get; set; }

        public Snack Snack { get; set; }

        public int Quantity { get; set; }

    }
}