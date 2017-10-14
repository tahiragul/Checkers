using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers_TahiraKhan
{
    public class BoardPieces
    {

        public int X { get; set; } //x coordination
        public int Y { get; set; } // y coordination
        public string Image { get; set; }// public string image { get; set; } 


        public BoardPieces(int x, int y, string image)
        {
            X = x;
            Y = y;
            Image = image;

        }
    }
}
