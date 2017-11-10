using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Checkers_TahiraKhan
{
    public class BoardPiece
    {
        public int X { get; set; } //x coordination
        public int Y { get; set; } // y coordination
        public string DefaultImage { get; set; }
        public string DefaultHighlightImage { get; set; }
        public Player Owner { get; set; }
        public bool selected = false; 
        public bool IsKing = false;
        public int RowForKing { get; set; }
        
        public string Status;//Active, Dead
        /// <summary>
        /// recieve player instance to set image depending on player's colour
        /// by default the player 1 is black and player2 is white
        /// </summary>
        /// <param name="player"></param>
        public BoardPiece(Player player)
        {
            if(player.isWhite()) // if player is white
            {
                DefaultImage = WHITE;
            }
            else
            {
                DefaultImage = BLACK; //if player is black
            }
            if(player.isWhite())
            {
                DefaultHighlightImage = WHITE_HIGHLIGHTED;//set default highlight image
            }
            else
            {
                DefaultHighlightImage = BLACK_HIGHLETD;
            }
            //
            if (player.BoardRowStart == 0)
            {
                RowForKing = player.BoardRowStart;// = 0;
            }
            else
            {
                RowForKing = player.BoardRowStart;// = 7;
            }
            
            Status = STATUS_ACTIVE;//
            Owner = player;
        }
        public bool isBlack()
        {
            return DefaultImage == BLACK || DefaultImage == BLACK_KING;
        }
        public bool isWhite()
        {
            return DefaultImage == WHITE || DefaultImage == WHITE_KING;
        }
        public string GetColor()
        {
            if (isBlack())
            {
                return Player.BLACK;
            }
            else
            {
                return Player.WHITE;
            }
        }
        public void MakeKing()
        {
            if (isBlack())
            {
                DefaultImage = BoardPiece.BLACK_KING;
                DefaultHighlightImage = BoardPiece.BLACK_KING_HIGHLIGHTED;
            }
            else
            {
                DefaultImage = BoardPiece.WHITE_KING;
                DefaultHighlightImage = BoardPiece.WHITE_KING_HIGHLIGHTED;
            }
            IsKing = true;            
        }
        public void MakeNormal()
        {
            if (isBlack())
            {
                DefaultImage = BoardPiece.BLACK;
                DefaultHighlightImage = BoardPiece.BLACK_HIGHLETD;
            }
            else
            {
                DefaultImage = BoardPiece.WHITE;
                DefaultHighlightImage = BoardPiece.WHITE_HIGHLIGHTED;
            }
            IsKing = false;
        }
        public const string WHITE = "Images\\whitePiece.jpg";
        public const string WHITE_HIGHLIGHTED = "Images\\wphl.png";
        public const string BLACK = "Images\\blackPiece1.png";
        public const string BLACK_HIGHLETD = "Images\\bphl.jpg";

        public const string WHITE_KING = "Images\\white_king.png";
        public const string WHITE_KING_HIGHLIGHTED = "Images\\wphl.png";
        public const string BLACK_KING = "Images\\black_king.png";
        public const string BLACK_KING_HIGHLIGHTED = "Images\\bphl.png";
        public const string STATUS_ACTIVE = "Active";
        public const string STATUS_DEAD = "Dead";
    }


}
