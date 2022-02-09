using VendaDeLanches.Models;

namespace VendaDeLanches.Repositories.Interfaces
{
    public interface ISnacksRepository
    {
        IEnumerable<Snack> Snacks { get; }

        IEnumerable<Snack> PreferredSnacks { get; }

        Snack GetSnackById(int SnackId);

    }
}
