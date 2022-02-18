using VendaDeLanches.Models;

namespace VendaDeLanches.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Snack> FavoriteSnacks { get; set; }
    }
}
