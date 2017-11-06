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
        Queue<char[,]> history = new Queue<char[,]>();
        List<char[,]> move = new List<char[,]>();
        List<char[,]> moveUndoList = new List<char[,]>();
        private Board board;
        private Menu menu = new Menu();
        
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
        /// recieve player's input for source and destination cells
        /// and call the movements check and execute that move
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
                        Console.Write("Please enter source cell position:");
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
                            Console.Write("Please enter destination cell position:");
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
                        else if ((movements.player1Turn) && (board.checkersboard[sourceRow, sourceCol] != ' '))
                        {
                            movements.movePlayer1(sourceRow, sourceCol, destinationRow, destinationCol);
                        }
                        else if (movements.player1Turn != true )
                        {
                            movements.movePlayer2(sourceRow, sourceCol, destinationRow, destinationCol);
                        }
                    }
                    history.Enqueue(board.checkersboard);
                    move.Add(board.checkersboard);
                    menu.DisplayCommands();
                    board.PrintBoard();
                    



                    Console.Write("Please Enter command: ");
                    choice = Console.ReadKey().KeyChar;
                    Console.WriteLine("\n");
                

                    switch (choice)
                    {
                        case 'c':
                            break;
                        case 'u':
                            Undo();
                            break;
                        case 'r':
                            Redo();
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
            DisplayHistory();
        }
        /// <summary>
        /// 
        /// </summary>
        public void DisplayHistory()
        {
            //while (history.Count > 0)
           // {
                foreach(char[,] contents in history)
                {
                    board.checkersboard = contents;
                    board.PrintBoard();

                }
               // char[,] contents = history.Dequeue();
                //movements.board.checkersboard = content;
                
               

                if (history.Count > 0)
                {
                    Console.WriteLine("Empty History");

                }
           // }
        }
        public void Undo()
        {
            if (move.Count > 0)
            {
                char[,] content = move[move.Count - 1];
                moveUndoList.Add(content);
                move.Remove(content);
                board.checkersboard = content;
                board.PrintBoard();
            }
            else
            {
                Console.WriteLine("Nothing to undo");
            }
        }
        public void Redo()
        {
            if (moveUndoList.Count > 0)
            {
                char[,] content = moveUndoList[moveUndoList.Count - 1];
                moveUndoList.Remove(content);
                board.checkersboard = content;
                board.PrintBoard();
            }
        }



    }
}
