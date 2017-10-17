using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers_TahiraKhan40227807
{
    public class Program
    {
        static void Main(string[] args)
        {


            char choice = ' ';


            do
            {
                DisplayMenu();
                Console.WriteLine("Please enter your choice:");

                choice = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");


                switch (choice)
                {
                    case '1':
                        PlayervsPlayer();
                        break;
                    case '2':
                        PlayervsAI();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
            while (choice != '4');
            void DisplayMenu()
            {
                Console.WriteLine("*********Checkers**********");
                Console.WriteLine("***************************");
                Console.WriteLine("    1. Player vs Player");
                Console.WriteLine("    2. Player vs AI");
                Console.WriteLine("    3. AI vs AI");
                Console.WriteLine("    4. Exit");
                Console.WriteLine("****************************");

                // Console.ReadLine();
            }



            void PlayervsPlayer()
            {
                Board board = new Board();
                board.Initboard();
                board.printBoard();

                board.MakeMove();

            }
            void PlayervsAI()
            {

            }



        }

    }
}
