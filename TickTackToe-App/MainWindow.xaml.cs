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

namespace TickTackToe_App
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _istErsterSpielerAmZug = true;


        public MainWindow()
        {
            InitializeComponent();
        }

       
        private void Kaestchen_Click(object sender, RoutedEventArgs e)
        {
            Button geklickterButton = (Button)sender;

            // Überprufng vom Spielfeld voll ja oder nein
            if (IstSpielfeldVoll())
            {
                Spielfeldleeren();
                _istErsterSpielerAmZug = true;
            }

            // Wenn ein Kästenchen belegt ist bekommt man eine Hinweis
            if (geklickterButton.Content != null && geklickterButton.Content.ToString() != "")
            {
                MessageBox.Show("Kästchen ist bereits belegt, versuch ein anderes!!!");
                return;
            }

            // Es wird hier definert wenn der erste Spieler am zug ist wird ein  X gestzt ansonsten wird ein O gesetzt
            if (_istErsterSpielerAmZug)
            {
                geklickterButton.Content = "X";
                _istErsterSpielerAmZug = false;
            }
            else
            {
                geklickterButton.Content = "O";
                _istErsterSpielerAmZug = true;
            }

            
        }

        // Hier wird überprüft ob das Spielfeld von unten voll ist wenn ja einmal leeren und wenn nicht, passier nix
        private bool IstSpielfeldVoll()
        {
            foreach (var item in Spielfeld.Children)
            {
                Button keastchen = item as Button;

                if(keastchen != null && keastchen.Content == string.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        // Hier wird das Grid angesprochen und geleert
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Spielfeldleeren();
        }

        // Hier wird jeder einzelne Button geleert
        private void Spielfeldleeren()
        {
            bt1_0_0.Content = string.Empty;
            bt2_0_1.Content = string.Empty;
            bt3_0_2.Content = string.Empty;

            bt4_1_0.Content = string.Empty;
            bt5_1_1.Content = string.Empty;
            bt6_1_2.Content = string.Empty;

            bt7_2_0.Content = string.Empty;
            bt8_2_1.Content = string.Empty;
            bt9_2_2.Content = string.Empty;
        }
    }
}
