using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TShirtShop.BLL;
using TShirtShop.Core.ViewModels;
using TShirtShop.Data;

namespace TShirtShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShirtRepository _shirtRepository;
        private readonly ShoppingCartServices _shoppingCartServices;

        public ShoppingCartController(IShirtRepository shirtRepository,ShoppingCartServices shoppingCartServices)
        {   
            _shirtRepository = shirtRepository;
            _shoppingCartServices = shoppingCartServices;
        }
        public IActionResult Index()
        {
            var items = _shoppingCartServices.GetShoppingCartItems();
            _shoppingCartServices.ShoppingCartItems = items;
            var shoppingCartViewModel = new ShoppingCartViewModel()
            {
                ShoppingCartItems = _shoppingCartServices.ShoppingCartItems,
                ShoppingCartTotal = _shoppingCartServices.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }
        public async Task<IActionResult> AddToShoppingCart(int shirtId)
        {
            var selectedShirt = await _shirtRepository.GetShirtBy(shirtId);
            if(selectedShirt != null)
            {
                _shoppingCartServices.AddToCart(selectedShirt, 1);
            }
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> RemoveFromShoppingCart(int shirtId)
        {
            var selectedShirt = await _shirtRepository.GetShirtBy(shirtId);
            
            if(selectedShirt != null)
            {
                _shoppingCartServices.RemoveFromCart(selectedShirt);
            }
           return RedirectToAction("Index");
        }
        public async Task <IActionResult>Submit(ShoppingCartViewModel shoppingCartViewModel)
        {
            if(shoppingCartViewModel.ShoppingCartItems.Count > 0)
            {

            }
            return RedirectToAction("Checkout", "Order");
        }
    }
}
