using VendaDeLanches.Context;
using VendaDeLanches.Models;
using VendaDeLanches.Repositories.Interfaces;

namespace VendaDeLanches.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Categories => _context.Categories;
    }
}
