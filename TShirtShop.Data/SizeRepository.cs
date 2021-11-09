using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TShirtShop.Core.Models;

namespace TShirtShop.Data
{
    public class SizeRepository : ISizeRepository
    {
        private readonly TShirtDbContext _dbContext;

        public SizeRepository(TShirtDbContext shirtDbContext)
        {
            _dbContext = shirtDbContext;
        }
        public async Task<Size[]> GetAllSizes()
        {
            IQueryable<Size> query = _dbContext.Sizes.Where(s=> s.IsActive ==true);
            return await query.ToArrayAsync();
        }

        public void Add(Size size)
        {
            _dbContext.Sizes.Add(size);

        }

        public int Commit()
        {
           return _dbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var size = _dbContext.Sizes.FirstOrDefault(s => s.SizeId == Id);
            if (size!= null)
            {
                _dbContext.Remove(size);
            }
        }

        public async Task<Size> GetById(int Id)
        {
            return _dbContext.Sizes.FirstOrDefault(s => s.SizeId == Id);
        }

        public Size Update(Size size)
        {
            var entity = _dbContext.Attach(size);
            entity.State = EntityState.Modified;
            return size;
        }
    }
}
