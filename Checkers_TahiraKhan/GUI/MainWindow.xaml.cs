using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Checkers_TahiraKhan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnpp.Focus();
        }

        /// <summary>
        /// this click button event instantiate the game object 
        /// that is inheriting from window and pass the game's name and game type
        /// then open the game window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void HUMAN_VS_HUMAN_Click(object sender, RoutedEventArgs e)
        {
            Game game1 = new Game("Checkers", Game.HUMAN_VS_HUMAN);
            game1.Show();
            this.Close();

        }
        private void HUMAN_VS_AI_Click(object sender, RoutedEventArgs e)
        {
            Game game1 = new Game("Checkers", Game.HUMAN_VS_AI);
            game1.Show();
            this.Close();

        }
        private void AI_VS_AI_Click(object sender, RoutedEventArgs e)
        {
            Game game1 = new Game("Checkers", Game.AI_VS_AI);
            game1.Show();
            this.Close();
        }        
    }
}
