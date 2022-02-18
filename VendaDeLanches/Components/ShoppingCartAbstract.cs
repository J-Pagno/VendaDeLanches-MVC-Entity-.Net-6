using Microsoft.AspNetCore.Mvc;
using VendaDeLanches.Models;
using VendaDeLanches.ViewModels;

namespace VendaDeLanches.Components
{
    public class ShoppingCartAbstract : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartAbstract(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke() 
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
    }
}
