using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Core.Models;

namespace TShirtShop.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TShirtDbContext _shirtDbContext;

        public OrderRepository(TShirtDbContext shirtDbContext)
        {
            _shirtDbContext = shirtDbContext;
        }
        public void Add(Order order)
        {
            _shirtDbContext.Orders.Add(order);
            _shirtDbContext.SaveChanges();
          
        }
    }
}
