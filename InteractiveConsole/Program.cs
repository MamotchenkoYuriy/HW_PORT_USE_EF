using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteractiveConsole.Views;
using Model;

namespace InteractiveConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            new InteractiveConsole().Menu("Меню");
            Console.ReadKey();
        }
    }
}
