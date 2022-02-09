using Microsoft.AspNetCore.Mvc;
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

        public IActionResult List()
        {
            //var snacks = _snackRepository.Snacks;

            //return View(snacks);

            var snackListViewModel = new SnackListViewModel();

            snackListViewModel.Snacks = _snackRepository.Snacks;
            snackListViewModel.currentCategory = "Categoria Atual";

            return View(snackListViewModel);

        }
    }
}
