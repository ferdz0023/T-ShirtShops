using System;
using System.Collections.Generic;
using System.Text;

namespace TShirtShop.Core.Models
{
    public class OrderDetail : Entity
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ShirtId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public Shirt Shirt { get; set; }
        public Order Order { get; set; }
    }
}
