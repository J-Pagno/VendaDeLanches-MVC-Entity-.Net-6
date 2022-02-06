using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaDeLanches.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [Display(Name = "Nome")]
        [StringLength(150, ErrorMessage = "O valor máximo é 100 caracteres.")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "A descrição da categoria é obrigatória.")]
        [Display(Name = "Descrição")]
        [StringLength(200, ErrorMessage = "O valor máximo é 200 caracteres.")]
        public string CategoryDescription { get; set; }

        //Define o relacionamento entre as tabelas 1 -> N
        public List<Snack> Snacks { get; set; }

    }
}
