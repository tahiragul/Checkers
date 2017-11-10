using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers_TahiraKhan
{
    public class PossibleMoves
    {
        public List<Move> All = new List<Move>();
        public List<Move> RejectedList = new List<Move>();
        public PossibleMoves(Player player, Board board)
        {
            foreach (BoardPiece piece in player.ActivePieces)
            {
                BoardCell sourceCell = board.content[piece.Y, piece.X];
                int possibleX;
                int possibleY;
                //Jump
                possibleX = piece.X + 2;
                possibleY = piece.Y + 2;
                if (possibleX < 8 && possibleY < 8)
                {
                    BoardCell destinationCell = board.content[possibleY, possibleX];
                    if (destinationCell.CurrentPiece == null)
                    {
                        Move move = new Move(sourceCell, destinationCell);
                        All.Add(move);
                    }
                }
                possibleX = piece.X + 2;
                possibleY = piece.Y - 2;
                if (possibleX < 8 && possibleY >= 0)
                {
                    BoardCell destinationCell = board.content[possibleY, possibleX];
                    if (destinationCell.CurrentPiece == null)
                    {
                        Move move = new Move(sourceCell, destinationCell);
                        All.Add(move);
                    }
                }
                possibleX = piece.X - 2;
                possibleY = piece.Y + 2;
                if (possibleX >= 0 && possibleY < 8)
                {
                    BoardCell destinationCell = board.content[possibleY, possibleX];
                    if (destinationCell.CurrentPiece == null)
                    {
                        Move move = new Move(sourceCell, destinationCell);
                        All.Add(move);
                    }
                }
                possibleX = piece.X - 2;
                possibleY = piece.Y - 2;
                if (possibleX >= 0 && possibleY >= 0)
                {
                    BoardCell destinationCell = board.content[possibleY, possibleX];
                    if (destinationCell.CurrentPiece == null)
                    {
                        Move move = new Move(sourceCell, destinationCell);
                        All.Add(move);
                    }
                }
                //1 step
                possibleX = piece.X + 1;
                possibleY = piece.Y + 1;
                if (possibleX < 8 && possibleY < 8)
                {
                    BoardCell destinationCell = board.content[possibleY, possibleX];
                    if (destinationCell.CurrentPiece == null)
                    {
                        Move move = new Move(sourceCell, destinationCell);
                        All.Add(move);
                    }
                }
                possibleX = piece.X + 1;
                possibleY = piece.Y - 1;
                if (possibleX < 8 && possibleY >= 0)
                {
                    BoardCell destinationCell = board.content[possibleY, possibleX];
                    if (destinationCell.CurrentPiece == null)
                    {
                        Move move = new Move(sourceCell, destinationCell);
                        All.Add(move);
                    }
                }

                possibleX = piece.X - 1;
                possibleY = piece.Y + 1;
                if (possibleX >= 0 && possibleY < 8)
                {
                    BoardCell destinationCell = board.content[possibleY, possibleX];
                    if (destinationCell.CurrentPiece == null)
                    {
                        Move move = new Move(sourceCell, destinationCell);
                        All.Add(move);
                    }
                }

                possibleX = piece.X - 1;
                possibleY = piece.Y - 1;
                if (possibleX >= 0 && possibleY >= 0)
                {
                    BoardCell destinationCell = board.content[possibleY, possibleX];
                    if (destinationCell.CurrentPiece == null)
                    {
                        Move move = new Move(sourceCell, destinationCell);
                        All.Add(move);
                    }
                }
            }
        }
        public Move GetNextBestMove()
        {
            //Random 
            if (All.Count > 0)
                return All[0];
            else
                return null;
        }
        public void AddToRejected(Move move)
        {
            RejectedList.Add(move);
        }
    }
}
