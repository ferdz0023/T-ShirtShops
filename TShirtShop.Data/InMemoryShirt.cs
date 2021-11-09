using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TShirtShop.Core.Models;

namespace TShirtShop.Data
{
    public class InMemoryShirt : IShirtRepository
    {
        private List<Shirt> Shirts;
        private readonly ISizeRepository _sizeRepository;
        public InMemoryShirt(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
            //Shirts = new List<Shirt>()
            //{
            //    new Shirt
            //    {
            //        Id = 1,SizeId = 2, 
            //        Size =  _sizeRepository.GetById(2), 
            //        Gender = GenderEnum.Male,Name = "C# Developer" , Description = "C# Developer",Price = 500,ImageLocation = "threadbird-logo-black.jpg" , ImageThumnNailLocation = "threadbird-logo-black.jpg"
            //    },
            //    new Shirt
            //    {
            //        Id = 2,SizeId = 1,
            //        Size =  _sizeRepository.GetById(1),
            //        Gender = GenderEnum.Male, Name = "Java Developer" , Description = "Java Developer",Price = 500,ImageLocation = "White_Tshirt.jpg" , ImageThumnNailLocation = "White_Tshirt.jpg"
            //    },

            //    new Shirt
            //    {
            //        Id = 3,SizeId = 3,
            //        Size = _sizeRepository.GetById(3),
            //        Gender = GenderEnum.Male, Name = "HTML", Description = "HTML",Price = 500,ImageLocation = "world-shirt_large.jpg" , ImageThumnNailLocation = "world-shirt_large.jpg"
            //    },
            //     new Shirt
            //    {
            //        Id = 4,SizeId = 3,
            //        Size = _sizeRepository.GetById(3),
            //        Gender = GenderEnum.Male, Name = "HTML", Description = "HTML",Price = 500,ImageLocation = "world-shirt_large.jpg" , ImageThumnNailLocation = "world-shirt_large.jpg"
            //    },
            //      new Shirt
            //    {
            //        Id = 6,SizeId = 3,
            //        Size = _sizeRepository.GetById(2),
            //        Gender = GenderEnum.Male, Name = "HTML", Description = "HTML",Price = 500,ImageLocation = "world-shirt_large.jpg" , ImageThumnNailLocation = "world-shirt_large.jpg"
            //    },
            //};
            
        }
        public IEnumerable<Shirt> AllShirts => Shirts;

        public ISizeRepository SizeRepository { get; }

        public void Add(Shirt shirt)
        {
            Shirts.Add(shirt);
        }

        public int Commit()
        {
            return 1;
        }

        public void Delete(int shirtId)
        {
            var shirt = Shirts.SingleOrDefault(s => s.ShirtId == shirtId);
            if(shirt != null)
            {
                Shirts.Remove(shirt);
            }
        }

        public int GetCountOfShirts()
        {
            return Shirts.Count();
        }

        public Shirt GetShirtBy(int shirtId)
        {
            return Shirts.SingleOrDefault(s => s.ShirtId == shirtId);
        }

        public Shirt Update(Shirt shirt)
        {
            var fromDB = Shirts.SingleOrDefault(s => s.ShirtId == shirt.ShirtId);
            fromDB.SizeId = shirt.SizeId;
            fromDB.Gender = shirt.Gender;
            fromDB.Description = shirt.Description;
            fromDB.Price = shirt.Price;
            return fromDB;
        }

        public Task<Shirt[]> GetShirt()
        {
            throw new NotImplementedException();
        }

        Task<Shirt> IShirtRepository.GetShirtBy(int shirtId)
        {
            throw new NotImplementedException();
        }

        public Task<Shirt[]> GetShirts()
        {
            throw new NotImplementedException();
        }
    }
}
