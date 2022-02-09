using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaDeLanches.Models
{
    [Table("ShoppingCartItens")]
    public class ShoppingCart
    {
        [Key]
        public string ShoppingCartId { get; set; }

        public Snack Snack { get; set; }

        public int Quantity { get; set; }

        [StringLength(200)]
        public int ShoppingCartItemId { get; set; }
    }
}
