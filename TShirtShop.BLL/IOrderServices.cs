using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Core.Models;

namespace TShirtShop.BLL
{
    public interface IOrderServices
    {
        void Insert(Order order);
    }
}
