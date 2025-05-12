using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellarManager.model
{
    internal abstract class Beverage
    {
        public string Name { get; set; }
        public double Degree { get; set; }

        protected Beverage(string name, double degree)
        {
            Name = name;
            Degree = degree;
        }
    }
}
