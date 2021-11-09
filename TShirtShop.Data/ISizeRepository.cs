using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TShirtShop.Core;
using TShirtShop.Core.Models;

namespace TShirtShop.Data
{
    public interface ISizeRepository
    {
        Task<Size[]> GetAllSizes();
        Task<Size> GetById(int Id);
        Size Update(Size size);
        void Add(Size size);
        void Delete(int Id);
        int Commit();
    }
}
