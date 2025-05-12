using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellarManager.model
{
    internal class Beer: Beverage
    {
        public TypeBeer Type { get; set; }
        public FormatBeer Format { get; set; }

        public Beer(string name, double degree, TypeBeer type, FormatBeer format) : base(name, degree)
        {
            Type = type;
            Format = format;
        }
    }
}
