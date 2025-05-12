using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    internal interface IStorage
    {
        public void SaveAllBeverages(List<Beverage> beverages); //con una lista di Beverage, la salva in un file, sovrascrive

        public void LoadAllBeverages(); //dal file crea una lista di Beverage
    }
}
