using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers_TahiraKhan
{
    /// <summary>
    /// store source, destination cells and piece for every move
    /// 
    /// </summary>
    public class Move
    {
        public BoardCell DestinationCell { get; set; }
        public BoardCell SourceCell { get; set; }
        public BoardPiece Piece { get; set; }
        public BoardPiece KilledPiece { get; set; }
        public bool isKing { get; set; }
        public Move(BoardCell SourceCell, BoardCell DestinationCell)
        {
            this.SourceCell = SourceCell;
            this.DestinationCell = DestinationCell;
            Piece = SourceCell.CurrentPiece;
        }
        /// <summary>
        /// set pieces at destinationation cell and clear source cell
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public bool Complete(Game game)
        {
            DestinationCell.SetPiece(Piece);//destination cell is set with the piece
            SourceCell.SetPiece(null);
            game.Movements.Push(this);// add to movement stack in the game to keep track of all the movements
            return true;
        }
        /// <summary>
        /// set piece back to source cell and clear destination cell
        /// draw an killed piece back
        /// if king was made during last move make it normal
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public bool Undo(Game game)
        {
            SourceCell.SetPiece(Piece); 
            DestinationCell.SetPiece(null);
            game.UndoMovements.Push(this);
            if (KilledPiece != null)
            {
                game.board.content[KilledPiece.Y, KilledPiece.X].SetPiece(KilledPiece);
                game.board.content[KilledPiece.Y, KilledPiece.X].UnSelect();
            }
            if (isKing)
            {
                Piece.MakeNormal();
            }
            return true;
        }
    }
}