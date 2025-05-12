using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    internal class Tui
    {
        private ILogic _logic;
        public Tui(ILogic logic)
        {
            _logic = logic;
        }

        internal void Start()
        {
            while (true) //inserire vino, inserire birra, oppure visualizzare lista beverages, fare preview conferma
            {
                Console.WriteLine("--------------------------\n| Welcome to the Cellar! |\n--------------------------\n");
                Console.WriteLine("[1] Add Beer");
                Console.WriteLine("[2] Add Wine");
                Console.WriteLine("[3] Show all beverages");
                Console.WriteLine("[4] Exit\n");
                Console.WriteLine("Insert");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        AddBeerGui();
                        break;
                    case "2":
                        //AddWineGui();
                        break;
                    case "3":
                        //GetAllBeveragesGui();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        internal void AddBeerGui()
        {
            Console.WriteLine("---------------\n| Adding Beer |\n---------------\n");

            while (true)
            {
                var name = "";
                double degree = 0.0;
                TypeBeer type = TypeBeer.Chiara;
                FormatBeer format = FormatBeer.Draft;

                Console.WriteLine("|| Name ||");
                Console.WriteLine("Insert");
                while (true)
                {
                    name = Console.ReadLine();
                    if (!string.IsNullOrEmpty(name))
                    {
                        break;
                    }
                    Console.WriteLine("Name cannot be empty");
                }

                Console.WriteLine("|| Alocoholic Degree ||");
                Console.WriteLine("Insert");
                while (true)
                {
                    var degreeStr = Console.ReadLine();

                    if (double.TryParse(degreeStr, out degree) && !string.IsNullOrEmpty(name))
                    {
                        if (degree >= 0 && degree <= 100)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Degree have to be between 0 - 100");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Degree have to be a number");
                    }
                }

                Console.WriteLine("||     Type Beer     ||");
                Console.WriteLine("[1] Chiara");
                Console.WriteLine("[2] Scura");
                Console.WriteLine("Insert");
                var typeStr = "";
                do
                {
                    typeStr = Console.ReadLine();
                    switch (typeStr)
                    {
                        case "1":
                            type = TypeBeer.Chiara;
                            break;
                        case "2":
                            type = TypeBeer.Scura;
                            break;
                        default:
                            break;
                    }
                }
                while (typeStr != "1" && typeStr != "2");

                Console.WriteLine("||    Format Beer    ||");
                Console.WriteLine("[1] Alla spina");
                Console.WriteLine("[2] Bottiglia");
                Console.WriteLine("Insert");
                var formatStr = "";
                do
                {
                    formatStr = Console.ReadLine();
                    switch (formatStr)
                    {
                        case "1":
                            format = FormatBeer.Draft;
                            break;
                        case "2":
                            format = FormatBeer.Bottle;
                            break;
                        default:
                            break;
                    }
                }
                while (formatStr != "1" && formatStr != "2");

                Console.WriteLine("||   Your Confirm    ||");
                Console.WriteLine($"Name: {name}, Alcoholic Degree: {degree}%, Type: {type}, Format: {format}");
                Console.WriteLine("[1] Confirm");
                Console.WriteLine("[2] Cancel");
                Console.WriteLine("Insert");
                var confirm = "";
                do
                {
                    confirm = Console.ReadLine();
                    switch (confirm)
                    {
                        case "1":
                            _logic.AddBeer(name, degree, type, format);
                            break;
                        case "2":
                            break;
                        default:
                            break;
                    }
                }
                while (confirm != "1" && confirm != "2");

                break;
            }
        }
    }
}
