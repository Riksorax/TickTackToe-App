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
using System.IO;

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

            //Hier wird die Background Farbe von dem Gewinner auf die ursprungfarbe zurück gesetzt und es wird ausgegeben welcher Spiele gewonnen hat
            var reiheGewonnen = sucheReiheGewonnen();

            if (reiheGewonnen.Count == 3)
            {
                ReiheGewonneBackground(reiheGewonnen[0], reiheGewonnen[1], reiheGewonnen[2]);

                if (_istErsterSpielerAmZug)
                {
                    MessageBox.Show("Spieler 2 mit dem O hat gewonnen");                   
                }
                else
                {
                    MessageBox.Show("Spieler 1 mit dem X hat gewonnen");
                }
                Spielfeldleeren();
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

        //IN einer neuen Liste wird hier defintiert welche Reihen kombinatoinen es gibt
        private List<Button> sucheReiheGewonnen()           
        {
            var resultat = new List<Button>();

            if (IstgleicherSpielStein(bt1_0_0, bt2_0_1, bt3_0_2))
            {
                resultat.Add(bt1_0_0);
                resultat.Add(bt2_0_1);
                resultat.Add(bt3_0_2);
            }
            else if (IstgleicherSpielStein(bt4_1_0, bt5_1_1, bt6_1_2))
            {
                resultat.Add(bt4_1_0);
                resultat.Add(bt5_1_1);
                resultat.Add(bt6_1_2);
            }
            else if (IstgleicherSpielStein(bt7_2_0, bt8_2_1, bt9_2_2))
            {
                resultat.Add(bt7_2_0);
                resultat.Add(bt8_2_1);
                resultat.Add(bt9_2_2);
            }
            else if (IstgleicherSpielStein(bt1_0_0, bt4_1_0, bt7_2_0))
            {
                resultat.Add(bt1_0_0);
                resultat.Add(bt4_1_0);
                resultat.Add(bt7_2_0);
            }
            else if (IstgleicherSpielStein(bt2_0_1, bt5_1_1, bt8_2_1))
            {
                resultat.Add(bt2_0_1);
                resultat.Add(bt5_1_1);
                resultat.Add(bt8_2_1);
            }
            else if (IstgleicherSpielStein(bt3_0_2, bt6_1_2, bt9_2_2))
            {
                resultat.Add(bt3_0_2);
                resultat.Add(bt6_1_2);
                resultat.Add(bt9_2_2);
            }
            else if (IstgleicherSpielStein(bt1_0_0, bt5_1_1, bt9_2_2))
            {
                resultat.Add(bt1_0_0);
                resultat.Add(bt5_1_1);
                resultat.Add(bt9_2_2);
            }
            else if (IstgleicherSpielStein(bt3_0_2, bt5_1_1, bt7_2_0))
            {
                resultat.Add(bt3_0_2);
                resultat.Add(bt5_1_1);
                resultat.Add(bt7_2_0);
            }
            return resultat;
        }

        //
        private bool IstgleicherSpielStein(Button erstesKaestchen, Button zweitesKaestchen, Button drittesKaestchen)
        {
            if(erstesKaestchen.Content.ToString() != ""
                && erstesKaestchen.Content.ToString() == zweitesKaestchen.Content.ToString()
                && zweitesKaestchen.Content.ToString() == drittesKaestchen.Content.ToString())
            {
                return true;
            }
            return false;
        }

        //Hier wird die Gewinner Reihe in Geld makiert
        private void ReiheGewonneBackground(Button erstesKaestchen, Button zweitesKaestechen, Button drittesKaesten)
        {
            erstesKaestchen.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
            zweitesKaestechen.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
            drittesKaesten.Background = (Brush)new BrushConverter().ConvertFrom("#FFCD00");
        }

        // Hier wird jeder einzelne Button geleert und dann in die ursprungsfarbe zurück geändert
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

            bt1_0_0.Background = (Brush)new BrushConverter().ConvertFrom("#00ffff");
            bt2_0_1.Background = (Brush)new BrushConverter().ConvertFrom("#00ffff");
            bt3_0_2.Background = (Brush)new BrushConverter().ConvertFrom("#00ffff");
            bt4_1_0.Background = (Brush)new BrushConverter().ConvertFrom("#00ffff");
            bt5_1_1.Background = (Brush)new BrushConverter().ConvertFrom("#00ffff");
            bt6_1_2.Background = (Brush)new BrushConverter().ConvertFrom("#00ffff");
            bt7_2_0.Background = (Brush)new BrushConverter().ConvertFrom("#00ffff");
            bt8_2_1.Background = (Brush)new BrushConverter().ConvertFrom("#00ffff");
            bt9_2_2.Background = (Brush)new BrushConverter().ConvertFrom("#00ffff");
        }
    }
}
