using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("1. Add Beer");
                Console.WriteLine("2. Add Wine");
                Console.WriteLine("3. Show all beverages");
                Console.WriteLine("4. Exit");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddBeer();
                        break;
                    case "2":
                        AddWine();
                        break;
                    case "3":
                        GetAllBeverages();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
            {

            }
        }
    }
}
