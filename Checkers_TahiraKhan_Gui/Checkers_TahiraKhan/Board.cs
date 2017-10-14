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
    class Board
    {
        private char[][] content = new char[8][];

        public BoardPieces[][] map; // jagged array of map elements
        

        private Game window;

       




        //constructor method for GridMap which get passed in a game object
        public Board(Game window)
        {
            this.window = window;

        }

        public void drawMap1()
        {
            
            content[0] = new char[] { 'f', 'b', 'f', 'b', 'f', 'b', 'f', 'b'};
            content[1] = new char[] { 'b', 'f', 'b', 'f', 'b', 'f', 'b', 'f'};
            content[2] = new char[] { 'f', 'b', 'f', 'b', 'f', 'b', 'f', 'b'};
            content[3] = new char[] { 'F', 'f', 'F', 'f', 'F', 'f', 'F', 'f' };
            content[4] = new char[] { 'f', 'F', 'f', 'F', 'f', 'F', 'f', 'F' };
            content[5] = new char[] { 'w', 'f', 'w', 'f', 'w', 'f', 'w', 'f'};
            content[6] = new char[] { 'f', 'w', 'f', 'w', 'f', 'w', 'f', 'w'};
            content[7] = new char[] { 'w', 'f', 'w', 'f', 'w', 'f', 'w', 'f'};

            map = new BoardPieces[content.Length][];
            for (int j = 0; j < content.Length; j++)
            {
                map[j] = new BoardPieces[content[j].Length];
            }

            for (int i = 0; i < content.Length; i++)
            {
                for (int j = 0; j < content[i].Length; j++)
                {

                    BoardPieces bp = new White(0, 0, "Images\\white.bmp");
                    if (content[i][j] == 'b')
                    {
                        BlackPiece blackpiece= new BlackPiece(i, j, "Images\\blackPiece1.png");
                         bp= blackpiece;


                    }
                    else if (content[i][j] == 'w')
                    {
                         WhitePiece whitepiece = new WhitePiece(i, j, "Images\\whitePiece.jpg");
                        bp = whitepiece;

                    }
                    else if (content[i][j] == 'F')
                    {
                        Black black = new Black(i, j, "Images\\black.gif");
                        bp = black;
                        
                    }
                    else if (content[i][j] == 'f')
                    {
                        White white = new White(i, j, "Images\\white.bmp");
                        bp = white;

                    }

                    map[i][j] = bp;
                    drawBoardElements(bp.Image, i, j);
                    
                }


            }

        }
       /* public void Checkers_mouseClick(object sender, MouseEventArgs e)
        {
           if(Mouse.LeftButton == MouseButtonState.Pressed)
            {
               // if(e.LeftButton == )
                //Move.move();
                reDraw();
            }

        }*/
        public void reDraw()
        {
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    drawBoardElements(map[i][j].Image, i, j);
                }
            }


        }
        // this method will create an image 
        //and add to the grid and position it
        public void drawBoardElements(string uriLocation, int row, int column)
        {
            //create an image
            Image img = new Image() { Source = new BitmapImage(new Uri(uriLocation, UriKind.Relative)) };
            window.appGrid.Children.Add(img);// add it to the grid
            Grid.SetRow(img, row);//position the image in the grid
            Grid.SetColumn(img, column);

        }

        internal void Checkers_MouseMove(KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
