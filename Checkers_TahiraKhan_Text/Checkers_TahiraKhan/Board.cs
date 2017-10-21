using Checkers_TahiraKhan;
using System;
using System.Collections.Generic;


namespace Checkers_TahiraKhan40227807
{
    public class Board
    {

        private char player1 = 'X';
        private char player2 = '0';
       // private bool gameEnd = false;
        private string turn = "Player1";
      //  private Player1 player1 = new Player1();
      //  Dictionary<string, object> TileLocation = new Dictionary<string, object>();


        private char[,] board = new char[8, 8];

        void DisplayCommands()
        {
            Console.WriteLine("*********Checkers Commands**********");
            Console.WriteLine("************************************");
            Console.WriteLine("    1. Player vs Player");
            Console.WriteLine("    2. Player vs AI");
            Console.WriteLine("    3. AI vs AI");
            Console.WriteLine("    4. Exit");
            Console.WriteLine("************************************");

            // Console.ReadLine();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Initboard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (((row + col) % 2) == 0)
                    {
                        board[row, col] = player1;
                    }
                    else
                    {
                        board[row, col] = ' ';
                    }
                }
            }
            for (int row = 5; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (((row + col) % 2) == 0)
                    {
                        board[row, col] = player2;
                    }
                    else
                    {
                        board[row, col] = ' ';
                    }
                }
            }                       
        }

        /// <summary>
        /// 
        /// </summary>
        public void printBoard()
        {
            Console.WriteLine("     0      1     2     3     4     5     6     7");
            
            for (int row = 0; row < 8; row++)
            {
                
                Console.WriteLine("  _________________________________________________");
                Console.Write(row);

                for (int col = 0; col < 8; col++)
                {
                    Console.Write("  |  " + board[row, col]);                   
                }

                Console.Write("  |  \n");                
            }

            Console.WriteLine("  _________________________________________________");
        }

        public void changeTurn()
        {
            if (turn == "Player1")
            {
                turn = "Player2";
                Console.WriteLine("Player2 Turn");
            }
            else if (turn == "Player2")
            {
                turn = "Player1";
                Console.WriteLine("Player1 Turn");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceRow"></param>
        /// <param name="sorceCol"></param>
        /// <returns></returns>
        public bool checkTurn(int sourceRow, int sorceCol)
        {
            if ((turn == "Player1") && (board[sourceRow, sorceCol] != 'X'))
            {
                Console.WriteLine("you can't use this piece");
                return false;
            }
            else if ((turn == "Player2") && (board[sourceRow, sorceCol] != '0'))
            {
                Console.WriteLine("you can't do this");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceRow"></param>
        /// <param name="sorceCol"></param>
        /// <param name="destinationRow"></param>
        /// <param name="destinationCol"></param>
        public void movePlayer1(int sourceRow, int sorceCol, int destinationRow, int destinationCol)
        {
            if (destinationRow == sourceRow + 1) 
            {
                if((destinationCol == sorceCol + 1) || (destinationCol == sorceCol - 1))
                {
                    board[destinationRow, destinationCol] = board[sourceRow, sorceCol];
                    board[sourceRow, sorceCol] = ' ';
                    changeTurn();
                }
                
            }


        }
        public void movePlayer2(int sourceRow, int sourceCol, int destinationRow, int destinationCol)
        {
            if (destinationRow == sourceRow - 1)
            {
                if ((destinationCol == sourceCol + 1) || (destinationCol == sourceCol - 1))
                {
                    board[destinationRow, destinationCol] = board[sourceRow, sourceCol];
                    board[sourceRow, sourceCol] = ' ';
                    changeTurn();
                }
            }

            if((board[sourceRow - 1, sourceCol - 1] == player1) || (board[sourceRow - 1, sourceCol + 1] == player1))
            {
                if((board[sourceRow - 2, sourceCol - 2] == player1) || (board[sourceRow - 2, sourceCol + 2] == player1))
                {

                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void MakeMove()
        {
            
         
            char decision = 'n';
            char choice = 'y';
            int sourceRow = 0;
            int sourceCol = 0;
            int destinationRow = 0;
            int destinationCol = 0;
            do
            {
                do
                {
                    Console.WriteLine("Please enter row coordinate of the player:");
                    sourceRow = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter col coordinate of the placoler:");
                    sourceCol = Convert.ToInt32(Console.ReadLine());
                    if (sourceRow < 0 || sourceCol > 7)
                    {
                        Console.WriteLine("Inavalid selection");
                        break;
                    }

                    if (checkTurn(sourceRow, sourceCol))
                    {
                        Console.WriteLine("Please enter row coordinate of the player:");
                        destinationRow = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please enter y coordinate of the player:");
                        destinationCol = Convert.ToInt32(Console.ReadLine());
                        if (destinationCol < 0 || destinationCol > 7)
                        {
                            Console.WriteLine("Inavalid selection");
                            break;
                        }
                        else if(turn == "Player1")
                        {
                            movePlayer1(sourceRow, sourceCol, destinationRow, destinationCol);
                           
                        }
                        else if (turn == "Player2")
                        {
                            movePlayer2(sourceRow, sourceCol, destinationRow, destinationCol);

                        }
                    }
                    reDraw();
                    DisplayCommands();
                    switch (choice)
                    {
                        case 'y':
                            decision = 'y';
                            break;
                        case 'u':
                          //  Undo();
                            break;
                        case 'r':
                          //  Redo();
                            break;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                    Console.WriteLine("Do you want to continue....");
                    choice = Console.ReadKey().KeyChar;
                    Console.WriteLine("\n");
                }
                while (choice != 'n');

                Console.WriteLine("Do you want to end the game");
                decision = Console.ReadKey().KeyChar;                

            }
            while (decision != 'y');


        }


        /// <summary>
        /// To redreaw a booard after every move
        /// </summary>
        public void reDraw()
        {
            Console.WriteLine("     0      1     2     3     4     5     6     7");

            for (int row = 0; row < 8; row++)
            {
                Console.WriteLine("  _________________________________________________");
                Console.Write(row);

                for (int col = 0; col < 8; col++)
                {
                    Console.Write("  |  " + board[row, col]);
                }
                Console.Write("  |  \n");
            }
            Console.WriteLine("  _________________________________________________");
        }
    }

    
}
