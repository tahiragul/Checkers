﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers_TahiraKhan
{
    public class PossibleMoves
    {
        public List<Move> ALLMoves = new List<Move>();
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
                        ALLMoves.Add(move);
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
                        ALLMoves.Add(move);
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
                        ALLMoves.Add(move);
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
                        ALLMoves.Add(move);
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
                        ALLMoves.Add(move);
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
                        ALLMoves.Add(move);
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
                        ALLMoves.Add(move);
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
                        ALLMoves.Add(move);
                    }
                }
            }
        }
        public Move GetNextBestMove()
        {           
            if (ALLMoves.Count > 0)
                return ALLMoves[0];
            else
                return null;
        }
    }
}
