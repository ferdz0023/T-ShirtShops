using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TShirtShop.BLL;
using TShirtShop.Core.Models;

namespace TShirtShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderServices _orderServices;
        private readonly ShoppingCartServices _shoppingCartServices;

        public OrderController(IOrderServices orderServices,ShoppingCartServices shoppingCartServices)
        {
            _orderServices = orderServices;
            _shoppingCartServices = shoppingCartServices;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCartServices.GetShoppingCartItems();
            _shoppingCartServices.ShoppingCartItems = items;

            if(_shoppingCartServices.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some shirts first");
            }

            if (ModelState.IsValid)
            {
                _orderServices.Insert(order);
                _shoppingCartServices.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon get your our awesome shirts";
            return View();
        }
    }
}
