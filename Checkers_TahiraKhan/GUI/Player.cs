using System;
using System.Collections.Generic;

namespace Checkers_TahiraKhan
{
    public class Player
    {   
        //player's properties
        public string Name { get; set; }
        public string Color { get; set; }
        public bool isAI { get; set; }
        public List<BoardPiece> ActivePieces = new List<BoardPiece>();
        public List<BoardPiece> KilledPieces = new List<BoardPiece>();        
        public int selectMove;
        public int BoardRowStart;//0 or 7
        //constructor to recieve and initialise player properties 
        public Player(int Side, string Color, bool isAI)
        {
            this.Color = Color;
            this.isAI = isAI;
            BoardRowStart = Side;//for player1 the row starts from 0 and for player2 from 7
        }
        //to deside on the move if player is AI
        public bool MakeMove(Board board)
        {
            bool result = false;
            if (isAI)
            {
                PossibleMoves possibleMoves = new PossibleMoves(this, board);

                Move move = possibleMoves.GetNextBestMove();
                while (result == false && move != null)
                {
                    board.SelectedCell = move.DestinationCell;
                    result = board.CompleteMove(move);
                    if (result == false)
                    {
                        possibleMoves.ALLMoves.Remove(move);
                        move = possibleMoves.GetNextBestMove();
                    }
                }
            }
            return result;
        }

        public bool isBlack()
        {
            return Color == BLACK;
        }
        public bool isWhite()
        {
            return Color == WHITE;
        }
        
        public const string WHITE = "WHITE";
        public const string BLACK = "BLACK";

        public const int Player1 = 0;
        public const int Player2 = 7;
    }
}
