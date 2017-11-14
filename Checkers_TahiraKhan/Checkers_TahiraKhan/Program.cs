using Checkers_TahiraKhan;
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
            Games game;
            Menu menu = new Menu();
            char choice = ' ';
            bool isAI = false;
            //display menue and allow user to select an option
            do
            {
                menu.DisplayMenu();
                Console.Write("Please enter your choice: ");
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
            while (choice != '3');
            
            //method to play player vs player game
            void PlayervsPlayer()
            {
                Board checkersboard = new Board();
                checkersboard.Initboard();
                checkersboard.PrintBoard();
                game = new Games(checkersboard);//pass the board instance to game
                game.MakeChoice();
            }
            void PlayervsAI()
            {
                
                Board checkersboard = new Board();
                checkersboard.Initboard();
                checkersboard.PrintBoard();
                game = new Games(checkersboard);//pass the board instance to game
                game.MakeMove();

            }



        }

    }
}
