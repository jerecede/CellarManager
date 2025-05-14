using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using CellarManager.model;

namespace CellarManager
{
    internal class JsonStorage : IStorage
    {
        public List<Beverage> LoadAllBeverages()
        {
            if (File.Exists("beverages.json"))
            {
                string json = File.ReadAllText("beverages.json");
                var dicts = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json);
                List<Beverage> beverages = new List<Beverage>();
                if(dicts != null)
                {
                    foreach (var dict in dicts)
                    {
                        if (dict["Class"] == "Beer")
                        {
                            TypeBeer type = (TypeBeer)Enum.Parse(typeof(TypeBeer), dict["TypeBeer"]);
                            FormatBeer format = (FormatBeer)Enum.Parse(typeof(FormatBeer), dict["FormatBeer"]);
                            beverages.Add(new Beer(dict["Name"], double.Parse(dict["Degree"]), type, format));
                        }
                        else if (dict["Class"] == "Wine")
                        {
                            TypeWine type = (TypeWine)Enum.Parse(typeof(TypeWine), dict["TypeWine"]);
                            beverages.Add(new Wine(dict["Name"], double.Parse(dict["Degree"]), type, dict["RegionWine"], int.Parse(dict["YearWine"])));
                        }
                    }
                    return beverages;
                }
            }
            return [];
        }

        public void SaveAllBeverages(List<Beverage> beverages)
        {
            //dictionary perche l'oggetto può variare da Wine e Beer,
            
            //ma in realta dovevano esserci tutti i campi condivisi come nel cdv x_x

            List<Dictionary<string, string>> dicts = [];
            foreach (var bev in beverages)
            {
                var dict = new Dictionary<string, string>()
                {
                    { "Class", (bev is Beer) ? "Beer" : "Wine" },
                    { "Name", bev.Name },
                    { "Degree", bev.Degree.ToString() },
                };

                if (bev is Beer)
                {
                    var beer = (Beer)bev;
                    dict.Add("TypeBeer", beer.Type.ToString());
                    dict.Add("FormatBeer", beer.Format.ToString());
                }
                else if (bev is Wine)
                {
                    var wine = (Wine)bev;
                    dict.Add("TypeWine", wine.Type.ToString());
                    dict.Add("RegionWine", wine.Region);
                    dict.Add("YearWine", wine.Year.ToString());
                }
                dicts.Add(dict);
            }

            string json = JsonSerializer.Serialize(dicts, new JsonSerializerOptions { WriteIndented = true });
            //string path = Path.Combine(Environment.CurrentDirectory, "beverages.json");
            File.WriteAllText("beverages.json", json);
        }
    }
}
