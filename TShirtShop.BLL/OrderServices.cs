using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Core.Models;
using TShirtShop.Data;

namespace TShirtShop.BLL
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCartServices _shoppingCartServices;

        public OrderServices(IOrderRepository orderRepository,ShoppingCartServices shoppingCartServices)
        {
            _orderRepository = orderRepository;
            _shoppingCartServices = shoppingCartServices;
        }
        public void Insert(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            var shoppingCartItems = _shoppingCartServices.ShoppingCartItems;
            order.OrderTotal = _shoppingCartServices.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();
            
            foreach(var shoppingCartItem in shoppingCartItems)
            {
                var orderdetail = new OrderDetail
                {
                    Qty = shoppingCartItem.Qty,
                    ShirtId = shoppingCartItem.ShirtId,
                    Price = shoppingCartItem.Shirt.Price
                };
                order.OrderDetails.Add(orderdetail);
            }
            _orderRepository.Add(order);
        }
    }
}
