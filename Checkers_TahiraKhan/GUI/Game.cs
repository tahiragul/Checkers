using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;//
using System.Windows.Input;
using System.Windows.Media;


namespace Checkers_TahiraKhan
{
    /// <summary>
    /// game class is a window that draw the 8x8 grid and other controls
    /// </summary>
    public class Game : Window
    {
        // create instances of ojects inheriting from window
        private Canvas gameCanvas;
        private Button returnButton;
        private Button UnDoButton;
        private Button RedoButton;
        private Button replayButton;
        public TextBlock instructionBlock { get; set; }
        public Border gridBorder { get; set; }
        public Grid appGrid { get; set; } // 
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Board board { get; set; }//propert of instance to access Board class
        public Stack<Move> Movements = new Stack<Move>();//stack of moves to add normal movements
        public Stack<Move> UndoMovements = new Stack<Move>();//stack to add undo movements
        public string GameType;
        //game constructor to to run initialize game method 
        public Game(string gameName, string GameType)
        {
            this.Title = gameName;
            this.GameType = GameType;
            initializeGame(); // call the initializeGame method     
        }

        // create and position window element
        //this method will call all the methods
        //to create canvas, grid and side panel
        private void initializeGame()
        {
            // set newly created canvas to be the content of the window
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            gameCanvas = new Canvas(); //create an object of canvas
            createGrid(); //call createGrid method
            createSidePanel(); //call createSidePanel method
            appGrid.Focus();
            CreatePlayers();
            //create an instance of board
            //passing it the current(this) window we have created containing the 8x8 grid
            //and then call the method to draw our grid – drawGrid1() 
            board = new Board(this);

            // call drawBoard method of Board class
            board.drawBoard();
            board.StartGame();//start game and set turn for player1
            
            this.Content = this.gameCanvas;

            //page event to triger 
            setupPageEvents();

        }
        //create players for the game and pass player's name, colour and if it is AI
        public void CreatePlayers()
        {
            switch (GameType){
                case HUMAN_VS_HUMAN:
                    CreateHumanPlayers();
                    break;
                case HUMAN_VS_AI:
                    CreateHumanVsAIPlayers();
                    break;
                case AI_VS_AI:
                    CreateAIPlayers();
                    break;
                default:
                    break;
                }
        }
        public void CreateHumanPlayers()
        {
            Player1 = new Player(Player.Player1, Player.BLACK, false);
            Player2 = new Player(Player.Player2, Player.WHITE, false);
        }
        public void CreateAIPlayers()
        {
            Player1 = new Player(Player.Player1, Player.BLACK, true);
            Player2 = new Player(Player.Player2, Player.WHITE, true);
        }
        public void CreateHumanVsAIPlayers()
        {
            Player1 = new Player(Player.Player1, Player.BLACK, false);
            Player2 = new Player(Player.Player2, Player.WHITE, true);
        }
        // create grid portion of the game
        private void createGrid()
        {
            // create Border around the grid
            gridBorder = new Border();
            gridBorder.BorderThickness = new Thickness(10.00);
            gridBorder.BorderBrush = Brushes.Brown;

            appGrid = new Grid();
            appGrid.Width = appGrid.Height = 500;
            appGrid.HorizontalAlignment = HorizontalAlignment.Left;
            appGrid.VerticalAlignment = VerticalAlignment.Top;
            appGrid.Focusable = true;
            appGrid.ShowGridLines = true;
            gridBorder.Child = appGrid;

            //create row and columns of grid
            for (int i = 0; i < 8; i++)
            {
                appGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int j = 0; j < 8; j++)
            {
                appGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
        //create the side bar portion of the main app page
        //	Call method to position all elements on the canvas
        private void createSidePanel()
        {
            instructionBlock = new TextBlock();
            instructionBlock.FontSize = 25;
            instructionBlock.Text = "Use mouse to move";
             
            //button to return to main page
            returnButton = new Button();
            returnButton.Height = 30;
            returnButton.Width = 245;
            returnButton.FontSize = 15;
            returnButton.Focusable = false;
            returnButton.Content = "Return to start page";

            UnDoButton = new Button();
            UnDoButton.Content = "Undo";
            UnDoButton.Height = 30;
            UnDoButton.Width = 100;
            UnDoButton.FontSize = 15;
            RedoButton = new Button();
            RedoButton.Content = "Redo";
            RedoButton.Height = 30;
            RedoButton.Width = 100;
            RedoButton.FontSize = 15;
            replayButton = new Button();
            replayButton.Content = "Redo";
            RedoButton.Height = 30;
            RedoButton.Width = 100;
            RedoButton.FontSize = 15;

            arrangeOnCanvas();
        }
        //Add and position each element on the canvas

        private void arrangeOnCanvas()
        {

            gameCanvas.Children.Add(instructionBlock);
            gameCanvas.Children.Add(returnButton);
            gameCanvas.Children.Add(UnDoButton);
            gameCanvas.Children.Add(RedoButton);
            gameCanvas.Children.Add(gridBorder);

            Canvas.SetLeft(instructionBlock, 550);
            Canvas.SetTop(instructionBlock, 100);

            Canvas.SetLeft(returnButton, 550);
            Canvas.SetTop(returnButton, 400);
            Canvas.SetLeft(UnDoButton, 550);
            Canvas.SetTop(UnDoButton, 200);
            Canvas.SetLeft(RedoButton, 650);
            Canvas.SetTop(RedoButton, 200);
        }
        //this method includes all the events 
        private void setupPageEvents()
        {
            returnButton.Click += returnButton_Click; //link event with the button with    
            UnDoButton.Click += UnDoButton_Click;
            RedoButton.Click += ReDoButton_Click;
        }

        //this event handler create an instance of main window
        //and navigate back to main window
        protected void returnButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            Player1 = null;
            Player1 = null;
            this.Close();
        }
        /// <summary>
        /// perform undo by remove last move from Movement stack
        /// and pushing it into UndoMovement stack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void UnDoButton_Click(object sender, RoutedEventArgs e)
        {
            if (Movements.Count > 0)
            {
                Move move = Movements.Pop();
                move.Undo(this);
                move.SourceCell.UnSelect();
                move.DestinationCell.UnSelect();
                this.board.SetTurn(move.Piece.Owner);
            }
        }
        /// <summary>
        /// remove the last move pushed in undoMovement stack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ReDoButton_Click(object sender, RoutedEventArgs e)
        {
            if (UndoMovements.Count > 0)
            {
                Move move = UndoMovements.Pop();
                move.Complete(this);
                this.board.ProcessKilledPiece(move);
                this.board.ProcessKingMove(move);
                move.SourceCell.UnSelect();
                move.DestinationCell.UnSelect();
                this.board.SetTurn(move.Piece.Owner);
                this.board.ChangeTurn();
            }
        }
        public const string HUMAN_VS_HUMAN = "HUMAN_VS_HUMAN";
        public const string HUMAN_VS_AI = "HUMAN_VS_AI";
        public const string AI_VS_AI = "AI_VS_AI";

    }    
}
