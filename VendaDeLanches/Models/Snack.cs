using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaDeLanches.Models
{
    [Table("Snacks")]
    public class Snack
    {
        [Key]
        public int SnackId { get; set; }

        [Required]
        [Display(Name = "Nome do Lanche")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2}")]
        public string SnackName { get; set; }

        [Required(ErrorMessage = "A descrição do lanche é obrigatória.")]
        [Display(Name = "Descrição do Lanche")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres.")]
        [MaxLength(200, ErrorMessage = "Descrição deve ter no máximo {1} caracteres.")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "A descrição detalhada do lanche é obrigatória")]
        [Display(Name = "Descrição Detalhada do Lanche")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres.")]
        [MaxLength(200, ErrorMessage = "Descrição deve ter no máximo {1} caracteres.")]
        public string DescriptionDetailed { get; set; }

        [Required(ErrorMessage = "A preço do lanche é obrigatória.")]
        [Display(Name = "Preço do Lanche")]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(1,999.99, ErrorMessage = "O preço deve estar entre R$1 e R$999,99.")]
        public decimal Price { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1}")]
        public string ImageURL { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1}")]
        public string ImageThumnailURL { get; set; }

        [Display(Name = "Favorito?")]
        public bool IsPreferred { get; set; }

        [Display(Name = "Estoque")]
        public bool InStock { get; set; }

        //Coluna
        public int CategoryId { get; set; }

        //Indica qual tabela ela fará referência - Propriedade de Navegação
        public virtual Category Category { get; set; }

    }
}
