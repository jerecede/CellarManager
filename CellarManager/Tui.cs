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
                Console.WriteLine("[4] Delete");
                Console.WriteLine("[5] Exit\n");
                Console.WriteLine("Insert");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        AddBeerGui();
                        break;
                    case "2":
                        Console.Clear();
                        AddWineGui();
                        break;
                    case "3":
                        Console.Clear();
                        GetBeveragesGui();
                        Console.WriteLine("\nPress any key to exit.");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        DeleteBeverageGui();
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        //int? year = int.TryParse(Console.ReadLine(), out int yearValue) ? yearValue : null;

        //private int ParseInt(string? input)
        //{
        //    int result = -1; //valore default

        //    try
        //    {
        //        result = int.Parse(input ?? "0");
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    return result;
        //}

        //private int ParseInt2(string? input)
        //{
        //    int result;

        //    try
        //    {
        //        result = int.Parse(input ?? "0");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        result = -1; //valore default
        //    }

        //    return result;
        //}

        //TryParse evitiamo di usare try e catch
        //private int ParseInt3(string? input)
        //{
        //    var success = int.TryParse(input, out int result);
        //    if(success) return result;
        //    return 0;
        //}

        internal void AddBeerGui()
        {
            Console.WriteLine("----------------------\n|     Adding Beer     |\n----------------------\n");

            while (true)
            {
                var name = "";
                double degree = 0.0;
                TypeBeer type = TypeBeer.Chiara;
                FormatBeer format = FormatBeer.Draft;

                Console.WriteLine("||       Name        ||");
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

                Console.Clear();

                Console.WriteLine("----------------------\n|     Adding Beer     |\n----------------------\n");
                Console.WriteLine($"Name: {name} - Alcoholic Degree: {degree}% - Type: {type} - Format: {format}\n");
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
                            Console.WriteLine("\nDone!");
                            Console.ReadKey();
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

        internal void AddWineGui()
        {
            Console.WriteLine("----------------------\n|     Adding Wine     |\n----------------------\n");

            while (true)
            {
                var name = "";
                double degree = 0.0;
                TypeWine type = TypeWine.Red;
                int year = 0;
                var region = "";

                Console.WriteLine("||       Name        ||");
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

                    if (double.TryParse(degreeStr, out degree) && !string.IsNullOrEmpty(degreeStr))
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

                Console.WriteLine("||     Type Wine     ||");
                Console.WriteLine("[1] White");
                Console.WriteLine("[2] Red");
                Console.WriteLine("[3] Rosè");
                Console.WriteLine("Insert");
                var typeStr = "";
                do
                {
                    typeStr = Console.ReadLine();
                    switch (typeStr)
                    {
                        case "1":
                            type = TypeWine.White;
                            break;
                        case "2":
                            type = TypeWine.Red;
                            break;
                        case "3":
                            type = TypeWine.Rose;
                            break;
                        default:
                            break;
                    }
                }
                while (typeStr != "1" && typeStr != "2" && typeStr != "3");

                Console.WriteLine("||       Year        ||");
                Console.WriteLine("Insert");
                while (true)
                {
                    var yearStr = Console.ReadLine();

                    if (int.TryParse(yearStr, out year) && !string.IsNullOrEmpty(yearStr))
                    {
                        if (year > 1900)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Year have to be bigger than 1900");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Degree have to be a number");
                    }
                }

                Console.WriteLine("||      Region       ||");
                Console.WriteLine("Insert");
                while (true)
                {
                    region = Console.ReadLine();
                    if (!string.IsNullOrEmpty(region))
                    {
                        break;
                    }
                    Console.WriteLine("Name cannot be empty");
                }

                Console.Clear();

                Console.WriteLine("----------------------\n|     Adding Beer     |\n----------------------\n");
                Console.WriteLine($"Name: {name} - Alcoholic Degree: {degree}% - Type: {type} - Region: {region} - Year: {year}\n");
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
                            _logic.AddWine(name, degree, type, region, year);
                            Console.WriteLine("\nDone!");
                            Console.ReadKey();
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

        internal void GetBeveragesGui()
        {
            Console.WriteLine("----------------\n| All Beverages |\n----------------\n");
            var beverages = _logic.GetBeverages();

            for (int i = 0; i < beverages.Count; i++)
            {
                var beverage = beverages[i];
                Console.WriteLine($"[{i}] {beverage.ToString()}");
            }
            
        }

        internal void DeleteBeverageGui()
        {
            GetBeveragesGui();
            Console.WriteLine("\nInsert number beverage to delete");
            
        }
    }
}
