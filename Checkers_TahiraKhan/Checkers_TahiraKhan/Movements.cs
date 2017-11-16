using Checkers_TahiraKhan40227807;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers_TahiraKhan
{
    //control all the movements
    public class Movements
    {
        public int sourceRow { get; set; }
        public int sourceCol { get; set; }
        public int destinationRow { get; set; }
        public int destinationCol { get; set; }

        public bool gameEnd = false;
        public Board board { get; set; }
        public bool player1Turn { get; set; }
        public Games games;
        private string winner;
        private Player1 player1 = new Player1();
        private Player2 player2 = new Player2();
        private char empty = ' ';
        private int last = 7;
        private int first = 0;
        private int player1Points = 0;
        private int player2Points = 0;
        
        /// <summary>
        /// constructor that recive the position for source and destination cells from game
        /// </summary>
        /// <param name="sourceR"></param>
        /// <param name="sourceC"></param>
        /// <param name="destinationR"></param>
        /// <param name="destinationC"></param>
        /// <param name="p1Turn"></param>
        /// <param name="gEnd"></param>
        /// <param name="myBoard"></param>
        public Movements(int sourceR, int sourceC, int destinationR, int destinationC, bool p1Turn, bool gEnd, Board myBoard)
        {
            board = myBoard;
            sourceRow = sourceR;
            sourceCol = sourceC;
            destinationRow = destinationR;
            destinationCol = destinationC;
            player1Turn = p1Turn;
            gameEnd = gEnd;
        }
        /// <summary>
        /// This method is called and proccessed 
        /// if it's a normal move for player1
        /// </summary>
        /// <param name="sourceRow"></param>
        /// <param name="sourceCol"></param>
        /// <param name="destinationRow"></param>
        /// <param name="destinationCol"></param>
        public void moveNormalPlayer1(int sourceRow, int sourceCol, int destinationRow, int destinationCol)
        {
            if (board.checkersboard[destinationRow, destinationCol] == empty)
            {
                if (destinationRow == last)
                {
                    board.checkersboard[destinationRow, destinationCol] = player1.King;
                    board.checkersboard[sourceRow, sourceCol] = empty;
                    player1Turn = false;
                }
                else
                {
                    board.checkersboard[destinationRow, destinationCol] = board.checkersboard[sourceRow, sourceCol];
                    board.checkersboard[sourceRow, sourceCol] = empty;
                    player1Turn = false;
                }
            }
            else
            {
                //error();
                Console.WriteLine("Invalid move");
            }
        }
        /// <summary>
        /// This method is called and proccessed 
        /// if it's a normal jump for player1
        /// </summary>
        /// <param name="sourceRow"></param>
        /// <param name="sourceCol"></param>
        /// <param name="destinationRow"></param>
        /// <param name="destinationCol"></param>
        public void jumpNormalPlayer1(int sourceRow, int sourceCol, int destinationRow, int destinationCol)
        {
            if ((board.checkersboard[sourceRow + 1, sourceCol + 1] == player2.Normal) && (board.checkersboard[sourceRow + 2, sourceCol + 2] == empty))
            {
                if (destinationRow == last)
                {
                    board.checkersboard[destinationRow, destinationCol] = player1.King;
                    board.checkersboard[sourceRow, sourceCol] = empty;
                    board.checkersboard[sourceRow + 1, sourceCol + 1] = empty;
                }
                else
                {
                    
                    board.checkersboard[destinationRow, destinationCol] = board.checkersboard[sourceRow, sourceCol];
                    board.checkersboard[sourceRow, sourceCol] = empty;
                    board.checkersboard[sourceRow + 1, sourceCol + 1] = empty;
                    player1Turn = false;
                }

            }
            else if ((board.checkersboard[sourceRow + 1, sourceCol - 1] == player2.Normal) && (board.checkersboard[sourceRow + 2, sourceCol - 2] == empty))
            {
                if (destinationRow == last)
                {
                    board.checkersboard[destinationRow, destinationCol] = player1.King;
                    board.checkersboard[sourceRow, sourceCol] = empty;
                    board.checkersboard[sourceRow + 1, sourceCol - 1] = empty;
                    player1Turn = false;
                }
                else
                {
                    board.checkersboard[destinationRow, destinationCol] = board.checkersboard[sourceRow, sourceCol];
                    board.checkersboard[sourceRow, sourceCol] = empty;
                    board.checkersboard[sourceRow + 1, sourceCol - 1] = empty;
                    player1Turn = false;
                }


            }
        }
        /// <summary>
        /// This method is called and proccessed 
        /// if it's a king move for player1
        /// </summary>
        /// <param name="sourceRow"></param>
        /// <param name="sourceCol"></param>
        /// <param name="destinationRow"></param>
        /// <param name="destinationCol"></param>
        public void movePlayer1King(int sourceRow, int sourceCol, int destinationRow, int destinationCol)
        {
            if (board.checkersboard[destinationRow, destinationCol] == empty)
            {
                board.checkersboard[destinationRow, destinationCol] = board.checkersboard[sourceRow, sourceCol];
                board.checkersboard[sourceRow, sourceCol] = empty;
                player1Turn = false;
            }
            else
            {
                //error();
                Console.WriteLine("Invalid move");
            }
        }
        /// <summary>
        /// This method is called and proccessed 
        /// if it's a king jump for player1
        /// </summary>
        /// <param name="sourceRow"></param>
        /// <param name="sourceCol"></param>
        /// <param name="destinationRow"></param>
        /// <param name="destinationCol"></param>
        public void jumpPlayer1King(int sourceRow, int sourceCol, int destinationRow, int destinationCol)
        {

            if (((board.checkersboard[sourceRow + 1, sourceCol + 1] == player2.Normal) || (board.checkersboard[sourceRow + 1, sourceCol + 1] == player2.King)) && (board.checkersboard[sourceRow + 2, sourceCol + 2] == empty))
            {
                board.checkersboard[destinationRow, destinationCol] = board.checkersboard[sourceRow, sourceCol];
                board.checkersboard[sourceRow, sourceCol] = empty;
                board.checkersboard[sourceRow + 1, sourceCol + 1] = empty;
                player1Turn = false;
            }
            else if ((board.checkersboard[sourceRow + 1, sourceCol - 1] == player2.Normal || board.checkersboard[sourceRow + 1, sourceCol - 1] == player2.King) && (board.checkersboard[sourceRow + 2, sourceCol - 2] == empty))
            {
                board.checkersboard[destinationRow, destinationCol] = board.checkersboard[sourceRow, sourceCol];
                board.checkersboard[sourceRow, sourceCol] = empty;
                board.checkersboard[sourceRow + 1, sourceCol - 1] = empty;
                player1Turn = false;

            }
            else if ((board.checkersboard[sourceRow - 1, sourceCol + 1] == player2.Normal || board.checkersboard[sourceRow - 1, sourceCol + 1] == player2.King) && (board.checkersboard[sourceRow - 2, sourceCol + 2] == empty))
            {
                board.checkersboard[destinationRow, destinationCol] = board.checkersboard[sourceRow, sourceCol];
                board.checkersboard[sourceRow, sourceCol] = empty;
                board.checkersboard[sourceRow - 1, sourceCol + 1] = empty;
                player1Turn = false;
            }
            else if ((board.checkersboard[sourceRow - 1, sourceCol - 1] == player2.Normal || board.checkersboard[sourceRow - 1, sourceCol - 1] == player2.King) && (board.checkersboard[sourceRow - 2, sourceCol - 2] == empty))
            {
                board.checkersboard[destinationRow, destinationCol] = board.checkersboard[sourceRow, sourceCol];
                board.checkersboard[sourceRow, sourceCol] = empty;
                board.checkersboard[sourceRow - 1, sourceCol - 1] = empty;
                player1Turn = false;

            }
            else
            {
                Console.WriteLine("You can't move");
            }

        }


        /// <summary>
        /// This method is called and proccessed 
        /// if it's a normal move for player2
        /// </summary>
        /// <param name="sourceRow"></param>
        /// <param name="sourceCol"></param>
        /// <param name="destinationRow"></param>
        /// <param name="destinationCol"></param>
        public void moveNormalPlayer2(int sourceRow, int sourceCol, int destinationRow, int destinationCol)
        {
            if (board.checkersboard[destinationRow, destinationCol] == empty)
                if (destinationRow == first)
                {
                    board.checkersboard[destinationRow, destinationCol] = player2.King;
                    board.checkersboard[sourceRow, sourceCol] = empty;
                    player1Turn = true;
                }
                else
                {
                    board.checkersboard[destinationRow, destinationCol] = board.checkersboard[sourceRow, sourceCol];
                    board.checkersboard[sourceRow, sourceCol] = empty;
                    player1Turn = true;
                }

            else
            {
                //error();
                Console.WriteLine("Invalid move");
            }


        }
        /// <summary>
        /// This method is called and proccessed 
        /// if it's a normal jump for player2
        /// </summary>
        /// <param name="sourceRow"></param>
        /// <param name="sourceCol"></param>
        /// <param name="destinationRow"></param>
        /// <param name="destinationCol"></param>
        public void jumpNormalPlayer2(int sourceRow, int sourceCol, int destinationRow, int destinationCol)
        {
            if ((board.checkersboard[sourceRow - 1, sourceCol + 1] == player1.Normal) && (board.checkersboard[sourceRow - 2, sourceCol + 2] == empty))
            {
                if (destinationRow == first)
                {
                    board.checkersboard[destinationRow, destinationCol] = player2.King;
                    board.checkersboard[sourceRow, sourceCol] = empty;
                    board.checkersboard[sourceRow - 1, sourceCol + 1] = empty;
                    player1Turn = true;
                }
                else
                {
                    board.checkersboard[destinationRow, destinationCol] = board.checkersboard[sourceRow, sourceCol];
                    board.checkersboard[sourceRow, sourceCol] = empty;
                    board.checkersboard[sourceRow - 1, sourceCol + 1] = empty;
                    player1Turn = true;
                }

            }
            else if ((board.checkersboard[sourceRow - 1, sourceCol - 1] == player1.Normal) && (board.checkersboard[sourceRow - 2, sourceCol - 2] == empty))
            {
                if (destinationRow == first)
                {
                    board.checkersboard[destinationRow, destinationCol] = player2.King;
                    board.checkersboard[sourceRow, sourceCol] = empty;
                    board.checkersboard[sourceRow - 1, sourceCol - 1] = empty;
                    player1Turn = true;

                }
                else
                {
                    board.checkersboard[destinationRow, destinationCol] = board.checkersboard[sourceRow, sourceCol];
                    board.checkersboard[sourceRow, sourceCol] = empty;
                    board.checkersboard[sourceRow - 1, sourceCol - 1] = empty;
                    player1Turn = true;
                }

            }
            else
            {
                Console.WriteLine("You can't move");
            }
        }
        /// <summary>
        /// This method is called and proccessed 
        /// if it's a king jump for player2
        /// </summary>
        /// <param name="sourceRow"></param>
        /// <param name="sourceCol"></param>
        /// <param name="destinationRow"></param>
        /// <param name="destinationCol"></param>
        public void movePlayer2King(int sourceRow, int sourceCol, int destinationRow, int destinationCol)
        {

            if (board.checkersboard[destinationRow, destinationCol] == empty)
            {
                board.checkersboard[destinationRow, destinationCol] = board.checkersboard[sourceRow, sourceCol];
                board.checkersboard[sourceRow, sourceCol] = empty;
                player1Turn = true;

            }
            else
            {
                //error();
                Console.WriteLine("Invalid move");
            }
        }
        /// <summary>
        /// This method is called and proccessed 
        /// if it's a king jump for player1
        /// </summary>
        /// <param name="sourceRow"></param>
        /// <param name="sourceCol"></param>
        /// <param name="destinationRow"></param>
        /// <param name="destinationCol"></param>
        public void jumpPlayer2King(int sourceRow, int sourceCol, int destinationRow, int destinationCol)
        {

            if ((board.checkersboard[sourceRow + 1, sourceCol + 1] == player1.Normal || board.checkersboard[sourceRow + 1, sourceCol + 1] == player1.King) && (board.checkersboard[sourceRow + 2, sourceCol + 2] == empty))
            {
                board.checkersboard[destinationRow, destinationCol] = board.checkersboard[sourceRow, sourceCol];
                board.checkersboard[sourceRow, sourceCol] = empty;
                board.checkersboard[sourceRow + 1, sourceCol + 1] = empty;
                player1Turn = true;
            }
            else if ((board.checkersboard[sourceRow + 1, sourceCol - 1] == player1.Normal || board.checkersboard[sourceRow + 1, sourceCol - 1] == player1.King) && (board.checkersboard[sourceRow + 2, sourceCol - 2] == empty))
            {
                board.checkersboard[destinationRow, destinationCol] = board.checkersboard[sourceRow, sourceCol];
                board.checkersboard[sourceRow, sourceCol] = empty;
                board.checkersboard[sourceRow + 1, sourceCol - 1] = empty;
                player1Turn = true;

            }
            else if ((board.checkersboard[sourceRow - 1, sourceCol + 1] == player1.Normal || board.checkersboard[sourceRow - 1, sourceCol + 1] == player1.King) && (board.checkersboard[sourceRow - 2, sourceCol + 2] == empty))
            {
                board.checkersboard[destinationRow, destinationCol] = board.checkersboard[sourceRow, sourceCol];
                board.checkersboard[sourceRow, sourceCol] = empty;
                board.checkersboard[sourceRow - 1, sourceCol + 1] = empty;
                player1Turn = true;
            }
            else if ((board.checkersboard[sourceRow - 1, sourceCol - 1] == player1.Normal || board.checkersboard[sourceRow - 1, sourceCol - 1] == player1.King) && (board.checkersboard[sourceRow - 2, sourceCol - 2] == empty))
            {
                board.checkersboard[destinationRow, destinationCol] = board.checkersboard[sourceRow, sourceCol];
                board.checkersboard[sourceRow, sourceCol] = empty;
                board.checkersboard[sourceRow - 1, sourceCol - 1] = empty;
                player1Turn = true;

            }
            else
            {
                Console.WriteLine("You can't move");
            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceRow"></param>
        /// <param name="sourceCol"></param>
        /// <param name="destinationRow"></param>
        /// <param name="destinationCol"></param>
        public void movePlayer1(int sourceRow, int sourceCol, int destinationRow, int destinationCol)
        {
            if (board.checkersboard[sourceRow, sourceCol] == player1.Normal && board.checkersboard[sourceRow, sourceCol] != empty)
            {
                if (((destinationRow == sourceRow + 1) && (destinationCol == sourceCol + 1)) || ((destinationRow == sourceRow + 1) && (destinationCol == sourceCol - 1)))
                {
                    moveNormalPlayer1(sourceRow, sourceCol, destinationRow, destinationCol);
                }

                else if (((destinationRow == sourceRow + 2) && (destinationCol == sourceCol + 2)) || ((destinationRow == sourceRow + 2) && (destinationCol == sourceCol - 2)))
                {
                    jumpNormalPlayer1(sourceRow, sourceCol, destinationRow, destinationCol);
                    player1Points++;
                }
                else
                {
                    Console.WriteLine("You can't move");
                }
            }
            else if (board.checkersboard[sourceRow, sourceCol] == player1.King)
            {
                if (((destinationRow == sourceRow + 1) && (destinationCol == sourceCol + 1)) || ((destinationRow == sourceRow + 1) && (destinationCol == sourceCol - 1)) || ((destinationRow == sourceRow - 1) && (destinationCol == sourceCol + 1)) || ((destinationRow == sourceRow - 1) && (destinationCol == sourceCol - 1)))
                {
                    movePlayer1King(sourceRow, sourceCol, destinationRow, destinationCol);
                }
                else if (((destinationRow == sourceRow + 2) && (destinationCol == sourceCol + 2)) || ((destinationRow == sourceRow + 2) && (destinationCol == sourceCol - 2)) || ((destinationRow == sourceRow - 2) && (destinationCol == sourceCol + 2)) || ((destinationRow == sourceRow - 2) && (destinationCol == sourceCol - 2)))
                {
                    jumpPlayer1King(sourceRow, sourceCol, destinationRow, destinationCol);
                    player1Points++;
                }
            }

            else
            {
                Console.WriteLine("invalid move");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceRow"></param>
        /// <param name="sourceCol"></param>
        /// <param name="destinationRow"></param>
        /// <param name="destinationCol"></param>
        public void movePlayer2(int sourceRow, int sourceCol, int destinationRow, int destinationCol)
        {
            if (board.checkersboard[sourceRow, sourceCol] == player2.Normal)
            {
                if (((destinationRow == sourceRow - 1) && (destinationCol == sourceCol + 1)) || ((destinationRow == sourceRow - 1) && (destinationCol == sourceCol - 1)))
                {
                    moveNormalPlayer2(sourceRow, sourceCol, destinationRow, destinationCol);
                }

                else if (((destinationRow == sourceRow - 2) && (destinationCol == sourceCol + 2)) || ((destinationRow == sourceRow - 2) && (destinationCol == sourceCol - 2)))
                {
                    jumpNormalPlayer2(sourceRow, sourceCol, destinationRow, destinationCol);
                    player2Points++;
                }
                else
                {
                    Console.WriteLine("invalid move");
                }
                if (board.checkersboard[sourceRow, sourceCol] == player2.King)
                {
                    if (((destinationRow == sourceRow + 1) && (destinationCol == sourceCol + 1)) || ((destinationRow == sourceRow + 1) && (destinationCol == sourceCol - 1)) || ((destinationRow == sourceRow - 1) && (destinationCol == sourceCol + 1)) || ((destinationRow == sourceRow - 1) && (destinationCol == sourceCol - 1)))
                    {
                        movePlayer2King(sourceRow, sourceCol, destinationRow, destinationCol);
                    }
                    else if (((destinationRow == sourceRow + 2) && (destinationCol == sourceCol + 2)) || ((destinationRow == sourceRow + 2) && (destinationCol == sourceCol - 2)) || ((destinationRow == sourceRow - 2) && (destinationCol == sourceCol + 2)) || ((destinationRow == sourceRow - 2) && (destinationCol == sourceCol - 2)))
                    {
                        jumpPlayer2King(sourceRow, sourceCol, destinationRow, destinationCol);
                        player2Points++;

                    }
                    else
                    {
                        Console.WriteLine("invalid move");
                    }
                }

                else
                {
                    Console.WriteLine("invalid move");
                }

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void CheckWin()
        {
            int totalPlayer1 = 0;
            int totalPlayer2 = 0;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board.checkersboard[row, col] == player1.Normal || board.checkersboard[row, col] == player1.King)
                    {
                        totalPlayer1++;
                    }
                    if (board.checkersboard[row, col] == player2.Normal || board.checkersboard[row, col] == player2.King)
                    {
                        totalPlayer2++;
                    }
                }
            }
            Console.WriteLine(totalPlayer1);
            Console.WriteLine(totalPlayer2);
            if (totalPlayer1 == 0)
            {
                winner = "Player2";
                Console.WriteLine(winner + " is a winner");
                gameEnd = true;
            }
            if (totalPlayer2 == 0)
            {
                winner = "Player1";
                Console.WriteLine(winner + " is a winner");
                gameEnd = true;
            }
        }

    }     

}
