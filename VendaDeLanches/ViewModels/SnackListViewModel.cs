using VendaDeLanches.Models;

namespace VendaDeLanches.ViewModels
{
    public class SnackListViewModel
    {
        //Define uma propriedade para exibir uma lista de lanches
        public IEnumerable<Snack> Snacks { get; set; }

        public string currentCategory { get; set; }

    }
}
