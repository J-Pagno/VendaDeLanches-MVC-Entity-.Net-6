using Microsoft.EntityFrameworkCore;
using VendaDeLanches.Context;
using VendaDeLanches.Models;
using VendaDeLanches.Repositories.Interfaces;

namespace VendaDeLanches.Repositories
{
    public class SnackRepository : ISnacksRepository
    {
        private readonly AppDbContext _context;

        public SnackRepository(AppDbContext context) 
        {
            _context = context;
        }

        public IEnumerable<Snack> Snacks => _context.Snacks.Include(c => c.Category);

        public IEnumerable<Snack> PreferredSnacks => _context.Snacks.
                                                                Where(s => s.IsPreferred).
                                                                Include(c => c.Category);

        public Snack GetSnackById(int SnackId)
        {
            return _context.Snacks.FirstOrDefault(s => s.SnackId == SnackId);
        }
    }
}
