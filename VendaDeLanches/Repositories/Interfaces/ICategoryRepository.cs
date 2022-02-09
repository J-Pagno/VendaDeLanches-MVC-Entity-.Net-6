using VendaDeLanches.Models;

namespace VendaDeLanches.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}