using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Core.Models;

namespace TShirtShop.Core.ViewModels
{
   public class ShoppingCartViewModel
    {
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
