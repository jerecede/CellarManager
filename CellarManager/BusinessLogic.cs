using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    internal class BusinessLogic: ILogic
    {
        private IStorage _storage;
        public BusinessLogic(IStorage storage)
        {
            _storage = storage;
        }

        public void AddBeer(Beer newBeer)
        {
            throw new NotImplementedException();
        }

        public void AddWine(Wine newWine)
        {
            throw new NotImplementedException();
        }

        public List<Beverage> GetAllBeverages()
        {
            throw new NotImplementedException();
        }
    }
}
