using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    internal interface ILogic
    {
        public void AddBeer(Beer newBeer); //passo i parametri di Beer, non istanza intera, cosi non se ne occupa la Tui
        public void AddWine(Wine newWine);
        public List<Beverage> GetAllBeverages();
    }
}
