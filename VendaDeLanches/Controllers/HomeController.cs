using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VendaDeLanches.Models;
using VendaDeLanches.Repositories.Interfaces;
using VendaDeLanches.ViewModels;

namespace VendaDeLanches.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISnacksRepository _snacksRepository;

        public HomeController(ISnacksRepository snacksRepository )
        {
            _snacksRepository = snacksRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                FavoriteSnacks = _snacksRepository.PreferredSnacks
            };

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}