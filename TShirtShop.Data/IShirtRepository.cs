using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TShirtShop.Core.Models;

namespace TShirtShop.Data
{
    public interface IShirtRepository
    {
        Task<Shirt[]> GetShirts();
        Task<Shirt> GetShirtBy(int shirtId);
        Shirt Update(Shirt shirt);
        void Add(Shirt shirt);
        void Delete(int shirtId);
        int GetCountOfShirts();
        int Commit();
    }
}
