using Microsoft.AspNetCore.Mvc;
using VendaDeLanches.Models;
using VendaDeLanches.Repositories.Interfaces;
using VendaDeLanches.ViewModels;

namespace VendaDeLanches.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ISnacksRepository _snackRepository;

        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ISnacksRepository snackRepository, ShoppingCart shoppingCart)
        {
            _snackRepository = snackRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var itens = _shoppingCart.GetShoppingCartItens();
            _shoppingCart.ShoppingCartItens = itens;

            var shoppingCartVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetTotalValueShoppingCart()
            };

            return View(shoppingCartVM);
        }

        public RedirectToActionResult AddShoppingCartItem(int snackId)
        {
            var selectedSnack = _snackRepository.Snacks
                .FirstOrDefault(s => s.SnackId == snackId);

            if (selectedSnack != null)
            {
                _shoppingCart.AddItem(selectedSnack);
            }

            return RedirectToAction("Index");
        }
            
        public IActionResult RemoveShoppingCartItem(int snackId)
        {
            var selectedSnack = _snackRepository.Snacks
                                .FirstOrDefault(s => s.SnackId == snackId);

            if (selectedSnack != null)
            {
                _shoppingCart.RemoveItem(selectedSnack);
            }

            return RedirectToAction("Index");
        }

    }
}
