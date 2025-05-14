using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    internal interface ILogic
    {
        public void AddBeer(string name, double degree, TypeBeer type, FormatBeer format); //passo i parametri di Beer, non istanza intera, cosi non se ne occupa la Tui
        public void AddWine(string name, double degree, TypeWine type, string region, int year);
        public void DeleteBeverage(int index);
        public List<Beverage> SearchBeverage(string text);
        public List<Beverage> GetBeverages();
    }
}
