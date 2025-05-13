using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellarManager.model
{
    internal class Wine: Beverage
    {
        public TypeWine Type { get; set; }
        public string Region { get; set; }
        public int Year { get; set; }

        public Wine(string name, double degree, TypeWine type, string region, int year) : base(name, degree)
        {
            Type = type;
            Region = region;
            Year = year;
        }

        public override string ToString()
        {
            return $"WINE: {base.ToString()} - {Type} - {Region} - {Year}";
        }

        public override string ToCsv()
        {
            return $"Wine, {base.ToCsv()},,, {Type}, {Region}, {Year}";
        }
    }
}
