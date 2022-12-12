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

namespace Morpion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private  Jeu _jeu;
        private bool _joueur;

        public MainWindow()
        {
            InitializeComponent();

            _jeu    = new Jeu();
            _joueur = true; // Les X commencent.
        }

        private void CelluleButton_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;

            int i = Grid.GetRow(bt);    // XAML : Grid.Row="..."
            int j = Grid.GetColumn(bt); //        Grid.Column="..."

            if (_jeu.Coche(_joueur, i, j))
            {
                if (_joueur)
                {
                    bt.Content = "X";
                }
                else
                {
                    bt.Content = "O";
                }

                if (_jeu.Gagnant(out bool gagnant))
                {
                    if (gagnant)
                        MessageBox.Show("Les X ont gagné");
                    else
                        MessageBox.Show("Les O ont gagné");
                }

                _joueur = !_joueur;
            }
        }

        private void RecommencerButton_Click(object sender, RoutedEventArgs e)
        {
            _jeu    = new Jeu();
            _joueur = true; // Les X commencent.

            // /!\ Dans le cas général, une Grid peut contenir n'importe quel contrôle.
            //     Dans ce cas particulier, il n'y a que des Button.
            foreach (Button bt in _celluleGrid.Children)
            {
                bt.Content = null;
            }
        }
    }
}
