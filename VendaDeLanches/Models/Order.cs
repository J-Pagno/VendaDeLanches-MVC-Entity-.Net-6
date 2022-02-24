using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaDeLanches.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        
        [Required(ErrorMessage = "O campo 'Nome' deve ser preenchido")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' deve ser preenchido")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O campo 'Endereço' deve ser preenchido")]
        [StringLength(100)]
        [Display(Name = "Endereço")]
        public int Endereco { get; set; }

        [StringLength(100)]
        [Display(Name = "Complemento")]
        public int Complement { get; set; }

        [Required(ErrorMessage = "O campo 'CEP' deve ser preenchido")]
        [StringLength(10, MinimumLength = 8)]
        [Display(Name = "CEP")]
        public int Cep { get; set; }

        [StringLength(10)]
        public int State { get; set; }

        [StringLength(10)]
        public int City { get; set; }

        [Required(ErrorMessage = "O campo 'Telefone' deve ser preenchido")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }

        [Required(ErrorMessage = "O campo 'E-Mail' deve ser preenchido")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "O email não possui um formato correto")]
        public int Email { get; set; }

        [ScaffoldColumn(false)] //Impede que isso seja apresentado na view
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "")]
        public decimal TotalOrder { get; set; }

        [ScaffoldColumn(false)] //Impede que isso seja apresentado na view
        [Display(Name = "Itens no Pedido")]
        public int TotalOrderItens { get; set; }

        [Display(Name = "Data Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime SentOrder { get; set; }

        [Display(Name = "Data Envio do Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDeliveredIn { get; set; }

        public List<OrderDetails> OrderItens { get; set; }


    }
}
