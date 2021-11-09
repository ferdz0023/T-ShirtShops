using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Core.Models;

namespace TShirtShop.Data
{
   public interface IOrderRepository
    {
        void Add(Order order);
    }
}
