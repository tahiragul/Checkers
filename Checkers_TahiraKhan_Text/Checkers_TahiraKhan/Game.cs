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
    class Game : Window
    {
        // create instances of ojects inheriting from window
        private Canvas gameCanvas;
        private Button returnButton;
        private TextBlock instructionBlock { get; set; }
        public static Label moves;// Label to display moves
        private Border gridBorder { get; set; }
        public Grid appGrid { get; set; } // instance of Grid control
        


        //propert of instance to access Board class
        private Board board { get; set; } 


        //game constructor to initialize all the methods
        public Game(string gameName)
        {
            this.Title = gameName;
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

            //create an instance of board
            //passing it the current(this) window we have created containing the 8x8 grid
            //and then call the method to draw our grid – drawGrid1() 
            board = new Board(this);


            // call drawMap1 method of gridmap class
             board.drawMap1();

            // dreaw canvas
            this.Content = this.gameCanvas;

            //page event to triger 
            setupPageEvents();

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
            Button button = new Button();

            //create row and columns of grid
            for (int r = 0; r < 8; r++)
            {
                appGrid.RowDefinitions.Add(new RowDefinition()); 
                
            }
            for (int c = 0; c < 8; c++)
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
            instructionBlock.Text = "Use mouse to move the pieces ";


            //Create label to display player's moves
            moves = new Label();
            moves.Content = "Total moves:";
            moves.FontSize = 14;
            // moves.Foreground = 


            //button to return to main page
            returnButton = new Button();
            returnButton.Height = 30;
            returnButton.Width = 245;
            returnButton.FontSize = 15;
            returnButton.Focusable = false;
            returnButton.Content = "Return to start page";

            arrangeOnCanvas();
        }
        //Add and position each element on the canvas

        private void arrangeOnCanvas()
        {

            gameCanvas.Children.Add(instructionBlock);
            gameCanvas.Children.Add(returnButton);
            gameCanvas.Children.Add(gridBorder);
            gameCanvas.Children.Add(moves);

            Canvas.SetLeft(instructionBlock, 100);
            Canvas.SetTop(instructionBlock, 530);

            Canvas.SetLeft(returnButton, 400);
            Canvas.SetTop(returnButton, 550);

            Canvas.SetTop(moves, 300);
            Canvas.SetRight(moves, 300);
        }

        //
       /* protected void appGrid_MouseMove(object sender, KeyEventArgs e)
        {
            board.Checkers_MouseMove(e);
        }*/
        //this method includes all the events 
        private void setupPageEvents()
        {
            returnButton.Click += returnButton_Click; //link event with the button with 
          //  appGrid.MouseMove += appGrid_MouseMove;// link keyDown event with the keys


        }

        //this event handler create an instance of main window
        //and navigate back to main window
        protected void returnButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }


    }
}
