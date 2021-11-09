using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TShirtShop.Core.Models;

namespace TShirtShop.BLL
{
    public interface IShirtServices 
    {
        void Insert(Shirt shirt);
        void Remove(int shirtId);
        Shirt Update(Shirt shirt);
        Task<Shirt> GetShirtBy(int shirtId);
        Task<Shirt[]> GetShirts();
    }
}
