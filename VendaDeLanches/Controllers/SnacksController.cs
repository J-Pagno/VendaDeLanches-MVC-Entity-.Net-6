using Microsoft.AspNetCore.Mvc;
using VendaDeLanches.Models;
using VendaDeLanches.Repositories.Interfaces;
using VendaDeLanches.ViewModels;

namespace VendaDeLanches.Controllers
{
    public class SnacksController : Controller
    {
        private readonly ISnacksRepository _snackRepository;

        public SnacksController(ISnacksRepository snackRepository)
        {
            _snackRepository = snackRepository;
        }

        public IActionResult List(string category)
        {
            IEnumerable<Snack> snacks;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                snacks = _snackRepository.Snacks.OrderBy(x => x.SnackId);
            }
            else 
            {
                if (string.Equals("Normal", category, StringComparison.OrdinalIgnoreCase))
                {
                    snacks = _snackRepository.Snacks.Where(sc => sc.Category.CategoryName.Equals("Normal"))
                        .OrderBy(s => s.SnackName);
                }
                else
                {
                    snacks = _snackRepository.Snacks.Where(sc => sc.Category.CategoryName.Equals("Natural"))
                        .OrderBy(s => s.SnackName);
                }

                currentCategory = category;
            }

            var snackListViewModel = new SnackListViewModel 
            {
                Snacks = snacks,
                currentCategory = currentCategory
            };

            return View(snackListViewModel);

        }
    }
}
