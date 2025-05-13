using CellarManager.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellarManager
{
    internal class CsvStorage : IStorage
    {
        public List<Beverage> LoadAllBeverages()
        {
            return [];
        }

        public void SaveAllBeverages(List<Beverage> beverages)
        {
            throw new NotImplementedException();
        }
    }
}
