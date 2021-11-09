using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TShirtShop.Core.Models
{
    public class ShoppingCartItem : Entity
    {
        public int ShoppingCartItemId { get; set; }
        [ForeignKey("Shirt")]
        public int ShirtId { get; set; }
        public Shirt Shirt { get; set; }
        public int Qty { get; set; }
        public string ShoppingCartId { get; set; }
       
    }
}
