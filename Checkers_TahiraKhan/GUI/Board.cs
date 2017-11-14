using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Checkers_TahiraKhan
{
    /// <summary>
    /// 
    /// </summary>
    public class Board
    {
        //create a 2D array of boardcell
        public BoardCell[,] content;
        private Game game;
        private Player turn;
        public BoardCell SelectedCell;
        //constructor method for board which get passed in a game object
        public Board(Game window)
        {
            this.game = window;
        }

        /// <summary>
        /// draw board using 2D array with alternate black and white cells
        /// and then populate with pieces on the black cell 
        /// </summary>
        public void drawBoard()
        {
            content = new BoardCell[8, 8];
            int cellColor = 1; // 0 for white and 1 for black
            string pieceColor = null;
            bool WhiteCell = false;

            for (int i = 0; i < 8; i++)// to generate alternate cell colours
            {
                if (cellColor == 0)
                    cellColor = 1;
                else
                    cellColor = 0;

                for (int j = 0; j < 8; j++)
                {
                    if (j % 2 == cellColor)// 0%2 = 0 mean white
                    {
                        WhiteCell = true;
                    }
                    else
                    {
                        WhiteCell = false;// 1 mean black
                    }
                    // to generate board pieces 
                    BoardPiece Piece = null;
                    //it will only generate pieces for black cells
                    //for first 3 rows and last 3 rows and where cellcolour is black
                    if ((i < 3 || i > 4) && WhiteCell == false)
                    {
                        //for first 3 rows of the board player1 pieces 
                        if (i < 3)
                        {
                            //get a colour from player1 to set piece colour for player1
                            pieceColor = game.Player1.Color;
                        }
                        else
                        {
                            pieceColor = game.Player2.Color;
                        }
                    }
                    else
                    {
                        pieceColor = null;
                    }
                    if (string.IsNullOrEmpty(pieceColor) == false)
                    {
                        if (i < 3)
                        {
                            Piece = new BoardPiece(game.Player1);//create a player1 piece
                        }
                        else
                        {
                            Piece = new BoardPiece(game.Player2);// create a player2 piece
                        }

                    }
                    else
                    {
                        Piece = null;
                    }

                    BoardCell Cell;
                    if (WhiteCell)//if WhiteCell= false that means white board cells
                    {
                        Cell = new BoardCell(i, j, BoardCell.WHITE_CELL, Piece);
                    }
                    else
                    {
                        Cell = new BoardCell(i, j, BoardCell.BLACK_CELL, Piece);
                    }
                    drawBoardElements(Cell); //draw cell on the grid
                    content[i, j] = Cell;
                    if (pieceColor == game.Player1.Color)
                    {
                        game.Player1.ActivePieces.Add(Piece);//add to list of active pieces for player1
                    }
                    else if (pieceColor == game.Player2.Color)
                    {
                        game.Player2.ActivePieces.Add(Piece);//add to list of active pieces for player2
                    }

                }
            }
        }

        /// <summary>
        /// change players turn to force them to take alternate turn
        /// </summary>
        public Player ChangeTurn()
        {
            if (turn == game.Player1)
            {
                SetTurn(game.Player2);
            }
            else
            {
                SetTurn(game.Player1);
            }
            return turn;
        }
        //return the player's turn 
        public Player GetTurn()
        {
            if (turn == null)
                return game.Player1;
            else
                return turn;

        }
        public Player SetTurn(Player player)
        {
            turn = player;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (turn.isAI == false)
                    {
                        content[i, j].MouseDown -= PieceMouseUp;
                        //if only the current piece colour matches the players turn 
                        if ((content[i, j].CurrentPiece == null || content[i, j].CurrentPiece.GetColor() == turn.Color))//Dont let select the opposite color
                        {
                            content[i, j].MouseDown += PieceMouseUp;
                        }
                    }
                    
                }
            }
            if (turn.isAI)
            {
                game.instructionBlock.Text = $"{turn.Color} Turn: Use mouse to move";
            }
            else
            {
                game.instructionBlock.Text = $"{turn.Color} Turn: Use mouse to move";
            }
            return turn;
        }
        //mouse up event 
        public void PieceMouseUp(object sender, MouseButtonEventArgs e)
        {
            bool result = SelectCellForMove(sender as BoardCell);
            if (result)
            {
                ChangeTurn();
                StartAI();//incase the opponet is an AI
            }
        }
        /// <summary>
        /// check if the selectected cell has got a piece
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public bool SelectCellForMove(BoardCell cell)
        {
            bool result = false;
            if (SelectedCell != null)
            {
                SelectedCell.UnSelect();
            }
            if (cell.CurrentPiece != null)
            {
                cell.Select();
                SelectedCell = cell;
            }
            //if source cell has got a piece and destination cell is empty
            else if (SelectedCell != null && cell.CurrentPiece == null)
            {
                Move move = new Move(SelectedCell, cell);
                result = CompleteMove(move);
            }
            return result;
        }
        public bool CompleteMove(Move move)
        {
            bool result = false;
            if (ValidateMove(move))
            {
                move.Complete(game);
                ProcessKilledPiece(move);
                ProcessKingMove(move);
                SelectedCell.UnSelect();
                move.DestinationCell.UnSelect();
                SelectedCell = null;
                result = true;
            }
            else
            {
                CheckWin();
            }
            return result;
        }
        public bool ValidateMove(Move move)
        {
            bool result = true;
            result = ValidateMoveForColor(move);
            if (result)
                result = ValidateMoveForDirection(move);
            if (result)
                result = ValidateMoveForDistance(move);
            return result;
        }
        public bool ValidateMoveForDistance(Move move)
        {
            bool result = false;
            int distanceX = 0;
            int distanceY = 0;
            distanceX = move.DestinationCell.X - move.SourceCell.X;
            distanceY = move.DestinationCell.Y - move.SourceCell.Y;
            if ((distanceY == 1 || distanceY == -1) && (distanceX == 1 || distanceX == -1))
            {
                result = true;
            }
            else if (GetKilledPieceCell(move) != null)
            {
                result = true;
            }
            return result;
        }
        public bool ProcessKingMove(Move move)
        {
            bool result = false;
            if (move.Piece.IsKing == false && (move.DestinationCell.CurrentPiece.Owner.BoardRowStart == Player.Player1 && move.DestinationCell.Y == Player.Player2 ||
                move.DestinationCell.CurrentPiece.Owner.BoardRowStart == Player.Player2 && move.DestinationCell.Y == Player.Player1))
            {
                move.Piece.MakeKing();
                move.isKing = true;
            }
            return result;
        }
        public bool ValidateMoveForDirection(Move move)
        {
            bool result = true;
            if (move.Piece.IsKing == false)
            {
                int High;
                int Low;
                if (move.Piece.Owner.BoardRowStart == 0)
                {
                    High = move.DestinationCell.Y;//row number greater than source cell
                    Low = move.SourceCell.Y;
                }
                else
                {
                    High = move.SourceCell.Y;
                    Low = move.DestinationCell.Y;
                }
                result = High > Low;
            }
            return result;
        }
        public bool ValidateMoveForColor(Move move)
        {
            return move.DestinationCell.isBlack();
        }
        //for jump over an oponent playe's piece
        //find if there is piece 
        public BoardCell GetKilledPieceCell(Move move)
        {
            bool result = false;
            int distanceX = 0;
            int distanceY = 0;
            distanceX = move.DestinationCell.X - move.SourceCell.X;
            distanceY = move.DestinationCell.Y - move.SourceCell.Y;

            if ((distanceY == 2 || distanceY == -2) && (distanceX == 2 || distanceX == -2))
            {
                int MidX;
                int MidY;
                if (distanceX == 2)
                {
                    MidX = move.SourceCell.X + 1;
                }
                else
                {
                    MidX = move.SourceCell.X - 1;
                }
                if (distanceY == 2)
                {
                    MidY = move.SourceCell.Y + 1;
                }
                else
                {
                    MidY = move.SourceCell.Y - 1;
                }
                //if 
                result = content[MidY, MidX].CurrentPiece != null && content[MidY, MidX].CurrentPiece.GetColor() != move.Piece.GetColor();
                if (result)
                    return content[MidY, MidX];
            }
            return null;
        }
        public void ProcessKilledPiece(Move move)
        {
            if (move != null)
            {
                BoardCell Cell = GetKilledPieceCell(move);
                if (Cell != null)
                {
                    move.KilledPiece = Cell.CurrentPiece;
                    Cell.CurrentPiece.Owner.KilledPieces.Add(Cell.CurrentPiece);//add to list of killed pieces
                    Cell.CurrentPiece.Owner.ActivePieces.Remove(Cell.CurrentPiece);//remove from active pieces
                    Cell.SetPiece(null);
                }
            }
        }
        public void StartGame()
        {
            Player p = SetTurn(game.Player1);
            if (turn.isAI == true)
            {
                StartAI(); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public async void StartAI()
        {
            if (turn.isAI == true)
            {
                bool result = true;
                while (result && turn.isAI)
                {
                    await Task.Delay(3000);
                    result = turn.MakeMove(this);
                    ChangeTurn();
                }
            }
        }
        /// <summary>
        /// check all the active pieces for both players
        /// if any player lose all the pieces then the other player is a winner
        /// </summary>
        public void CheckWin()
        {
            if (game.Player1.ActivePieces.Count < 1)
            {
                MessageBox.Show("Player2 is  a winner");
                game.Player1 = null;
                game.Player1 = null;
                game.Close();
            }
            else if (game.Player2.ActivePieces.Count < 1)
            {
                MessageBox.Show("Player1 is a winner");
                game.Player1 = null;
                game.Player1 = null;
                game.Close();         
            }
        }
        // this method will create an image 
        //and add to the board and position it
        public void drawBoardElements(BoardCell Cell)
        {
            string image;
            if (Cell.CurrentPiece == null)
            {
                image = Cell.DefaultImage;
            }
            else
            {
                image = Cell.CurrentPiece.DefaultImage;
            }
            Cell.Source = new BitmapImage(new Uri(image, UriKind.Relative));
            game.appGrid.Children.Add(Cell);// add it to the grid
            Grid.SetRow(Cell, Cell.Y);//position the image in the grid
            Grid.SetColumn(Cell, Cell.X);
        }
    }
}
