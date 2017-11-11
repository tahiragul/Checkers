using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers_TahiraKhan
{
    public class Move
    {
        public BoardCell DestinationCell { get; set; }
        public BoardCell SourceCell { get; set; }
        public BoardPiece Piece { get; set; }
        public string Status { get; set; }//New or Complete
        public BoardPiece KilledPiece { get; set; }
        public bool isKing { get; set; }
        public Move(BoardCell SourceCell, BoardCell DestinationCell)
        {
            this.SourceCell = SourceCell;
            this.DestinationCell = DestinationCell;
            Piece = SourceCell.CurrentPiece;
        }
        /// <summary>
        /// recieve game window as parameter and add a move to list
        /// return true once the move is complete
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public bool Complete(Game game)
        {
            DestinationCell.SetPiece(Piece);//destination cell is set with the piece
            SourceCell.SetPiece(null);
            game.Movements.Push(this);// add to movement list in the game to keep track of all the movements
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public bool Undo(Game game)
        {

            SourceCell.SetPiece(Piece); //set 
            DestinationCell.SetPiece(null);
            game.UndoMovements.Push(this);//add move to a list in the game class
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