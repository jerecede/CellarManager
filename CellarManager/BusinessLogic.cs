using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    internal class BusinessLogic : ILogic
    {
        private IStorage _storage;
        public List<Beverage> Beverages { get; set; } = new List<Beverage>();

        public BusinessLogic(IStorage storage)
        {
            _storage = storage;
            Beverages = _storage.LoadAllBeverages();
        }

        public void AddBeer(string name, double degree, TypeBeer type, FormatBeer format)
        {
            return;
        }

        public void AddWine(string name, double degree, TypeWine type, string region, int year)
        {
            return;
        }

        public List<Beverage> GetAllBeverages()
        {
            return [];
        }
    }
}
