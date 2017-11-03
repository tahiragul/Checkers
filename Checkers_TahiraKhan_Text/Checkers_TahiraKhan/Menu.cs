using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers_TahiraKhan
{
    public class Menu
    {
        public void DisplayMenu()
        {
            Console.WriteLine("*********Checkers**********");
            Console.WriteLine("***************************");
            Console.WriteLine("    1. Player vs Player");
            Console.WriteLine("    2. Player vs AI");
            Console.WriteLine("    3. Exit");
            Console.WriteLine("****************************");
        }
        public void DisplayCommands()
        {
            Console.WriteLine("*********Checkers Commands**********");
            Console.WriteLine("************************************");
            Console.WriteLine("    1. Press 'c' to Countinue");
            Console.WriteLine("    2. Press 'u' to Undo");
            Console.WriteLine("    3. Press 'r' to Redo");
            Console.WriteLine("    4. Press 'e' to Exit");
            Console.WriteLine("************************************");
        }
    }
}
