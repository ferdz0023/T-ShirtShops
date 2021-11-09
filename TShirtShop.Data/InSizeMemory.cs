using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TShirtShop.Core;
using TShirtShop.Core.Models;

namespace TShirtShop.Data
{
    public class InSizeMemory : ISizeRepository
    {
        List<Size> sizes = new List<Size>();
        public InSizeMemory()
        {
            sizes = new List<Size>()
            {
                new Size {SizeId = 1,Name = "Small"},
                new Size {SizeId = 2,Name = "Medium"},
                new Size {SizeId = 3,Name = "Large"}

            };
        }

        public IEnumerable<Size> GetAllSizes => sizes.OrderBy(s=> s.Name);

        public void Add(Size size)
        {
            sizes.Add(size);
        }

        public int Commit()
        {
            return 1;
        }

        public void Delete(int Id)
        {
            var size = sizes.SingleOrDefault(s => s.SizeId == Id);
            sizes.Remove(size);
        }

        public Size GetById(int Id)
        {
            return sizes.SingleOrDefault(s => s.SizeId == Id);
        }

        public Size Update(Size size)
        {
            var fromDB = sizes.SingleOrDefault(s => s.SizeId == size.SizeId);
            fromDB.Name = size.Name;
            return size;
        }

        Task<Size[]> ISizeRepository.GetAllSizes()
        {
            throw new NotImplementedException();
        }

        Task<Size> ISizeRepository.GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
