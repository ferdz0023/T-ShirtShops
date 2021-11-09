using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TShirtShop.Core.Models;
using TShirtShop.Data;

namespace TShirtShop.BLL
{
    public class ShirtServices : IShirtServices
    {
        private readonly IShirtRepository _shirtRepository;

        public ShirtServices(IShirtRepository shirtRepository)
        {
            _shirtRepository = shirtRepository;
        }
        public async Task<Shirt[]> GetShirts()
        {
            return await _shirtRepository.GetShirts();
        }

        public async Task<Shirt> GetShirtBy(int shirtId)
        {
            return await _shirtRepository.GetShirtBy(shirtId);
        }

        public void Insert(Shirt shirt)
        {
            _shirtRepository.Add(shirt);
            _shirtRepository.Commit();
        }

        public void Remove(int shirtId)
        {
            _shirtRepository.Delete(shirtId);
            _shirtRepository.Commit();
        }

        public Shirt Update(Shirt shirt)
        {
            return _shirtRepository.Update(shirt);
        }
    }
}
