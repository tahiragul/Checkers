using Checkers_TahiraKhan40227807;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers_TahiraKhan
{
    public class Games
    {
        public int sourceRow { get; set; }
        public int sourceCol { get; set; }
        public int destinationRow { get; set; }
        public int destinationCol { get; set; }
        private bool player1Turn = true;
        private Player1 player1 = new Player1();
        private Player2 player2 = new Player2();
        
        List<Board> history = new List<Board>();
        private Board board;
        private Board newBoard;
        private Menu menu = new Menu();
        //List<char[,]> history = new List<char[,]>();
        List<char> history1 = new List<char>();
        private bool gameEnd = false;
        Movements movements;

        /// <summary>
        /// recieve the board as an argument
        /// </summary>
        /// <param name="myBoard"></param>
        public Games(Board myBoard)
        {
            board = myBoard;
            
        }

        /// <summary>
        /// check players turn and display message asking player to chose right cell position
        /// </summary>
        /// <param name="sourceRow"></param>
        /// <param name="sourceCol"></param>
        /// <returns></returns>
        public bool checkTurn(int sourceRow, int sourceCol)
        {
            if (((board.checkersboard[sourceRow, sourceCol] == player2.Normal) || (board.checkersboard[sourceRow, sourceCol] == player2.King)) && (movements.player1Turn == true))
            {
                Console.WriteLine("Its' Player1 Turn");
                return false;
            }
            else if (((board.checkersboard[sourceRow, sourceCol] == player1.Normal) || (board.checkersboard[sourceRow, sourceCol] == player1.King)) && (movements.player1Turn == false))
            {
                Console.WriteLine("Its' Player2 Turn");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void MakeMove()
        {
            char decision = 'n';
            char choice = 'c';
            movements = new Movements(sourceRow, sourceCol, destinationRow, destinationCol, player1Turn, gameEnd, board);

            do
            {
                do
                {
                    
                    try
                    {
                        Console.Write("Please enter cell position to move player:");
                        string s = Console.ReadLine();
                        string[] values = s.Split(',');
                        sourceRow = int.Parse(values[0]);
                        sourceCol = int.Parse(values[1]);


                        if (sourceRow < 0 || sourceCol > 7)
                        {
                            Console.WriteLine("Inavalid selection");
                            break;
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("not valid");
                    }

                    if (checkTurn(sourceRow, sourceCol))
                    {
                        try
                        {
                            Console.Write("Please enter cell position to move player:");
                            string s = Console.ReadLine();
                            string[] values = s.Split(',');
                            destinationRow = int.Parse(values[0]);
                            destinationCol = int.Parse(values[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("not valid");
                        }


                        if (destinationCol < 0 || destinationCol > 7)
                        {
                            Console.WriteLine("Inavalid selection");
                            break;
                        }
                        else if (movements.player1Turn)
                        {
                            movements.movePlayer1(sourceRow, sourceCol, destinationRow, destinationCol);
                        }
                        else if (movements.player1Turn != true)
                        {
                            movements.movePlayer2(sourceRow, sourceCol, destinationRow, destinationCol);
                        }
                    }
                    newBoard.checkersboard = board.checkersboard;                        
                    history.Add(newBoard);
                    menu.DisplayCommands();
                    reDraw();
                    Console.Write("Please Enter command: ");
                    choice = Console.ReadKey().KeyChar;
                    Console.WriteLine("\n");
                    switch (choice)
                    {
                        case 'c':
                            choice = 'y';
                            break;
                        case 'u':
                            //  Undo();
                            break;
                        case 'r':
                            //  Redo();
                            break;
                        case 'e':
                            break;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                    movements.CheckWin();
                }
                while (choice != 'e' && movements.gameEnd != true); //false
                Console.WriteLine("Do you want to end the game");
                decision = Console.ReadKey().KeyChar;
            }
            while (!gameEnd && decision != 'y');
            displayHistory1();
        }
        /// <summary>
        /// To redraw booard after every move
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
                    Console.Write("  |  " + movements.board.checkersboard[row, col]);
                    

                }
                Console.Write("  |  \n");
            }
            Console.WriteLine("  _________________________________________________");
            Console.WriteLine("     0      1     2     3     4     5     6     7");
            
        }
        public void displayHistory()
        {
            Console.WriteLine("     0      1     2     3     4     5     6     7");

            for (int row = 0; row < 8; row++)
            {
                Console.WriteLine("  _________________________________________________");
                Console.Write(row);

                for (int col = 0; col < history1.Count; col++)
                {
                    Console.Write("  |  " + history1);
                    
                }
                Console.Write("  |  \n");
            }
            Console.WriteLine("  _________________________________________________");
            Console.WriteLine("     0      1     2     3     4     5     6     7");
        }
        public void displayHistory1()
        {
           foreach(object board in history)
            {
                Console.WriteLine("     0      1     2     3     4     5     6     7");

                for (int row = 0; row < 8; row++)
                {
                    Console.WriteLine("  _________________________________________________");
                    Console.Write(row);

                    for (int col = 0; col < 8; col++)
                    {
                        Console.Write("  |  " + newBoard.checkersboard[row,col]);

                    }
                    Console.Write("  |  \n");
                }
                Console.WriteLine("  _________________________________________________");
                Console.WriteLine("     0      1     2     3     4     5     6     7");

                
            }
        }

    }
}
