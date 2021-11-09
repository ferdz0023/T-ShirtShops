using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TShirtShop.Core.Models;
using TShirtShop.Data;

namespace TShirtShop.BLL
{
    public class ShoppingCartServices
    {
        private readonly TShirtDbContext _dbContext;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        private ShoppingCartServices(TShirtDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public static ShoppingCartServices GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            var context = services.GetService<TShirtDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCartServices(context) { ShoppingCartId = cartId };


        }
        public void AddToCart(Shirt shirt, int qty)
        {
            var shoppingCartItem = _dbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Shirt.ShirtId == shirt.ShirtId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    ShirtId = shirt.ShirtId,
                    Qty = 1
                };
                _dbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Qty++;

            }
            _dbContext.SaveChanges();
        }
        public int RemoveFromCart(Shirt shirt)
        {
            var shoppingCartItem =
                _dbContext.ShoppingCartItems.SingleOrDefault(
                    s => s.Shirt.ShirtId == shirt.ShirtId && s.ShoppingCartId == ShoppingCartId);

            var localQty = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Qty > 1)
                {
                    shoppingCartItem.Qty--;
                    localQty = shoppingCartItem.Qty;

                }
                else
                {
                    _dbContext.ShoppingCartItems.Remove(shoppingCartItem);

                }
            }
            _dbContext.SaveChanges();

            return localQty;


        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems =
                    _dbContext.ShoppingCartItems
                    .Where(c => c.ShoppingCartId == ShoppingCartId)
                    .Include(s => s.Shirt)
                    .ToList());
        }
        public void ClearCart()
        {
            var cartItems = _dbContext.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId);

            _dbContext.RemoveRange(cartItems);
            _dbContext.SaveChanges();
        }
        public decimal GetShoppingCartTotal()
        {
            var total = _dbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Shirt.Price * c.Qty).Sum();
            return total;
        }
    }
}
