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


            if (!string.IsNullOrEmpty(category))
            {
                snacks = _snackRepository.Snacks.Where(sc => sc.Category.CategoryName.Equals(category))
                    .OrderBy(s => s.SnackName);
            }
            else
            {
                snacks = _snackRepository.Snacks;
            }

            currentCategory = category;

            var snackListViewModel = new SnackListViewModel
            {
                Snacks = snacks,
                currentCategory = currentCategory
            };

            return View(snackListViewModel);

        }

        public IActionResult Details(int snackId)
        {
            var snackToDetail = _snackRepository.Snacks.FirstOrDefault(s => s.SnackId == snackId);
            return View(snackToDetail);
        }

    }
}
