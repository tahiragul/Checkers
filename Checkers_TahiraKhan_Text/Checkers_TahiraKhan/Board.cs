using Checkers_TahiraKhan;
using System;
using System.Collections.Generic;


namespace Checkers_TahiraKhan40227807
{
    public class Board
    {

        private char player1 = 'X';
        private char player2 = '0';
        private bool gameEnd = false;
        private string decision = "no";
        private string turn = "Player1";
      //  private Player1 player1 = new Player1();
        Dictionary<string, object> TileLocation = new Dictionary<string, object>();

       






        private char[,] board = new char[8, 8];

        public void Initboard()
        {
        

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (((x + y) % 2) == 0)
                    {
                        board[y, x] = 'B';

                    }
                    else
                    {
                        board[y, x] = 'W';
                    }

                }
            }
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (board[x, y] == 'B')
                    {
                       
                        board[x, y] = player1;
                    }

                }
            }
            for (int y = 0; y < 8; y++)
            {
                for (int x = 5; x < 8; x++)
                {
                    if (board[x, y] == 'B')
                    {
                       // Player1 player1 = new Player1();
                        board[x, y] = player2;
                    }

                }
            }


        }

        public void printBoard()
        {
            Console.WriteLine("    0    1   2   3   4   5   6   7");
            
            for (int y = 0; y < 8; y++)
            {
                
                Console.WriteLine("  _________________________________");
                Console.Write(y);

                for (int x = 0; x < 8; x++)
                {

                    Console.Write(" | " + board[y, x]);
                    

                }

                Console.Write(" | \n");
               


            }



            Console.WriteLine("  _________________________________");
            


        }

        public void changeTurn()
        {
            if (turn == "Player1")
            {
                turn = "Player2";
            }
            else if (turn == "Player2")
            {
                turn = "Player1";
            }

        }

          public bool checkTurn(int sourceX, int sourceY)
          {
              if((turn == "Player1") && (board[sourceX, sourceY] != 'X'))
              {
                  Console.WriteLine("It's player1 turn");
                  return false;

              }
              else if ((turn == "Player2") && (board[sourceX, sourceY] != '0'))
              {
                  Console.WriteLine("It's player2 turn");
                  return false;

              }
              else { return true; }

          }
        public void movePlayer1()
        {
        }

       
        public void MakeMove()
        {
            gameEnd = false;
            do
            {
                Console.WriteLine("Please enter x coordinate of the player:");
                int sourceX = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter y coordinate of the player:");
                int sourceY = Convert.ToInt32(Console.ReadLine());

                if (checkTurn(sourceX, sourceY))
                {
                    if ((turn == "player1"))
                    {
                        movePlayer1();

                    }
                        

                    
                     
                        
                            
                }
                /* {
                     Console.WriteLine("It's player1 turn");


                 }
                 else if ((turn == "Player2") && (board[sourceY, sourceX] != '0'))
                 {
                     Console.WriteLine("It's player2 turn");

                 }*/
                {
                    Console.WriteLine("Please enter x coordinate of the player:");
                    int destinationX = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter y coordinate of the player:");
                    int destinationY = Convert.ToInt32(Console.ReadLine());
                    if ((destinationX < 0 && destinationX > 8) || (destinationY < 0 && destinationY > 8))
                    {
                        Console.WriteLine("Inavalid move");
                    }
                    else
                    {
                        if()
                        board[destinationX, destinationY] = board[sourceX, sourceY];
                        board[sourceX, sourceY] = 'B';
                        changeTurn();
                        reDraw();

                    }
                }
                
                
                Console.WriteLine("Do you want to end the game");
                decision = Console.ReadLine();
                if (decision == "yes")
                {
                    gameEnd = true;
                }

            }
            while (!gameEnd);


        }
        public void reDraw()
        {
            Console.WriteLine("    0    1   2   3   4   5   6   7");

            for (int y = 0; y < 8; y++)
            {

                Console.WriteLine("  _________________________________");
                Console.Write(y);

                for (int x = 0; x < 8; x++)
                {

                    Console.Write(" | " + board[y, x]);


                }

                Console.Write(" | \n");



            }



            Console.WriteLine("  _________________________________");



        }
    }

    
}
