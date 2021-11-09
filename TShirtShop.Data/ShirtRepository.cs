using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TShirtShop.Core.Models;

namespace TShirtShop.Data
{
    public class ShirtRepository : IShirtRepository
    {
        private readonly TShirtDbContext _dbContext;
        private readonly ISizeRepository _sizeRepository;

        public ShirtRepository(TShirtDbContext shirtDbContext,ISizeRepository sizeRepository)
        {
            _dbContext = shirtDbContext;
            _sizeRepository = sizeRepository;
        }
        public async Task<Shirt[]> GetShirts()
        {
            IQueryable<Shirt> query = _dbContext.Shirts.Where(s=> s.IsActive == true).Include(b=> b.Size);
            return await query.ToArrayAsync();

        }

        public void Add(Shirt shirt)
        {
            try
            {
                _dbContext.Add(shirt);
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
            
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Delete(int shirtId)
        {
            var shirt = _dbContext.Shirts.FirstOrDefault(s => s.ShirtId == shirtId);
            shirt.IsActive = false;
            if (shirt != null)
            {
                shirt.IsActive = false;
                Update(shirt);
            }
        }

        public int GetCountOfShirts()
        {
            throw new NotImplementedException();
        }

        public async Task<Shirt> GetShirtBy(int shirtId)
        {
            var shirt = _dbContext.Shirts.AsNoTracking().FirstOrDefault(s => s.ShirtId == shirtId && s.IsActive == true);
            return shirt;
        }

        public Shirt Update(Shirt shirt)
        {
            var entity = _dbContext.Attach(shirt);
            entity.State = EntityState.Modified;
            Commit();
            return  shirt;
        }
    }
}
