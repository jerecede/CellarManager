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
            if (File.Exists("beverages.json"))
            {
                string[] lines = File.ReadAllLines("beverages.csv");
                List<Beverage> beverages = new List<Beverage>();
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts[0] == "Beer")
                    {
                        TypeBeer type = (TypeBeer)Enum.Parse(typeof(TypeBeer), parts[3]);
                        FormatBeer format = (FormatBeer)Enum.Parse(typeof(FormatBeer), parts[4]);
                        beverages.Add(new Beer(parts[1], double.Parse(parts[2]), type, format));
                    }
                    else if (parts[0] == "Wine")
                    {
                        TypeWine type = (TypeWine)Enum.Parse(typeof(TypeWine), parts[5]);
                        beverages.Add(new Wine(parts[1], double.Parse(parts[2]), type, parts[6], int.Parse(parts[7])));
                    }
                }
                return beverages;
            }
            return [];

        }

        public void SaveAllBeverages(List<Beverage> beverages)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Class, Name, Degree, TyperBeer, FormataBeer, TypeWine, RegionWine, YearWine");
            foreach (var bev in beverages)
            {
                builder.AppendLine(bev.ToCsv());
                File.WriteAllText("beverages.csv", builder.ToString());
            }
        }
    }
}
