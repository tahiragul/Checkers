using Checkers_TahiraKhan;
using System;
using System.Collections.Generic;


namespace Checkers_TahiraKhan40227807
{
    /// <summary>
    /// This class initiate and print board filled with empty spaces then
    /// populate board with player1 and Player2 pieces
    /// </summary>
    public  class Board
    {
        private Player1 player1 = new Player1();
        private Player2 player2 = new Player2();
        private char empty = ' ';
        public char[,] checkersboard = new char[8, 8];
        public Menu menu = new Menu();
 
        public Board()
        {
            this.checkersboard = new char[8, 8];
        }
        
        public void Initboard()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    checkersboard[row, col] = empty;
                    if (row >= 0 && row < 3)
                    {
                        if (((row + col) % 2) == 0)
                        {
                            checkersboard[row, col] = player1.Normal;
                        }
                        else
                        {
                            checkersboard[row, col] = empty;
                        }
                    }
                    if (row >= 5  && row < 8)
                    {
                        if (((row + col) % 2) == 0)
                        {
                            checkersboard[row, col] = player2.Normal;
                        }
                        else
                        {
                            checkersboard[row, col] = empty;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// print board
        /// </summary>
        public void PrintBoard()
        {
            for (int row = 0; row < 8; row++)
            {
                Console.WriteLine("  _________________________________________________");
                Console.Write(row);

                for (int col = 0; col < 8; col++)
                {
                    Console.Write("  |  " + checkersboard[row, col]);
                }

                Console.Write("  |  \n");
            }

            Console.WriteLine("  _________________________________________________");
            Console.WriteLine("     0      1     2     3     4     5     6     7");            
        }
        
    }
}
    


    


