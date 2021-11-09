using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TShirtShop.BLL;

namespace TShirtShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShirtServices _shirtServices;

        public HomeController(IShirtServices shirtServices)
        {
            _shirtServices = shirtServices;
        }
        public async Task<IActionResult> Index()
        {
            var shirts = await _shirtServices.GetShirts();
            return View(shirts);
        }
    }
}
