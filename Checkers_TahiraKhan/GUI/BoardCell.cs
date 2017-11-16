using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
namespace Checkers_TahiraKhan
{
    /// <summary>
    /// this class create board cells 
    /// </summary>
    public class BoardCell : Image
    {
        public string DefaultImage { get; set; }
        public string DefaultHighlightImage { get; set; }
        public int X { get; set; }//x coordinate 
        public int Y { get; set; }//y coordinate
        public BoardPiece CurrentPiece { get; set; }

        public BoardCell(int Y, int X, string CellType)
        {
            DefaultImage = CellType;
            DefaultHighlightImage = CellType;
            this.X = X;
            this.Y = Y;
        }
        //constructor with the piece
        public BoardCell(int Y, int X, string CellType, BoardPiece Piece)
        {
            DefaultImage = CellType;
            DefaultHighlightImage = CellType;
            this.X = X;
            this.Y = Y;
            SetPiece(Piece);//set the piece as current piece

        }
        //set the source image with the image
        public void SetSourceImage(string url)
        {
            var bitmap = new BitmapImage(new Uri(url, UriKind.Relative));
            this.Source = bitmap;
        }
        /// <summary>
        /// recieve BoardPiece and set it as current piece
        /// </summary>
        /// <param name="Piece"></param>
        /// <returns></returns>
        public bool SetPiece(BoardPiece Piece)
        {
            CurrentPiece = Piece;
            if (CurrentPiece != null)
            {
                CurrentPiece.X = X;
                CurrentPiece.Y = Y;
                SetSourceImage(CurrentPiece.DefaultHighlightImage);
            }
            else
            {
                SetSourceImage(DefaultImage);
            }
            return true;
        }
        public bool isBlack()
        {
            return DefaultImage == BLACK_CELL;
        }
        public bool isWhite()
        {
            return DefaultImage == WHITE_CELL;
        }
        public bool Select()
        {
            if (this.CurrentPiece == null)
            {
                SetSourceImage(DefaultHighlightImage);
            }
            else
            {
                SetSourceImage(CurrentPiece.DefaultHighlightImage);                
            }

            return true;
        }
        public bool UnSelect()
        {
            if (this.CurrentPiece == null)
            {
                SetSourceImage(DefaultImage);                
            }
            else
            {
                SetSourceImage(CurrentPiece.DefaultImage);                
            }
            return true;
        }
        public const string WHITE_CELL = "Images\\white.bmp";
        public const string BLACK_CELL = "Images\\black.gif";
      
    }
}
