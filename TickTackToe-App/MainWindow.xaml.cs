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

    
        enum CasketStatus
        {
            Empty,
            FirstPlayer,
            SecondPlayer
            
        }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string firstPlayerStone = "X";
        private const string secondPlayerStone = "O";

        private CasketStatus[] _casket;
        private bool isFirstPlayer;
        private bool _isGameClose;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Casket_Click(object sender, RoutedEventArgs e)
        {
            if (_isGameClose)
            {
                StartNewGame();
                return;
            }

            var aktuellesUicasket = (Button)sender;
            var spaltenIndex = Grid.GetColumn(aktuellesUicasket);
            var zeilenIndex = Grid.GetRow(aktuellesUicasket);
            var logikIndex = spaltenIndex + (zeilenIndex * 3);

            if (_casket[logikIndex] != CasketStatus.Empty)
            {
                return;
            }

            if (isFirstPlayer)
            {
                aktuellesUicasket.Content = firstPlayerStone;
                _casket[logikIndex] = CasketStatus.FirstPlayer;
                isFirstPlayer = false;
            }
            else
            {
                aktuellesUicasket.Content = secondPlayerStone;
                aktuellesUicasket.Background = (Brush)new BrushConverter().ConvertFrom("#310000");
                aktuellesUicasket.Foreground = (Brush)new BrushConverter().ConvertFrom("#14c600");
                _casket[logikIndex] = CasketStatus.SecondPlayer;
                isFirstPlayer = true;
            }



            if (IsGameClose())
             {
                 _isGameClose = true;
             }
            
         }

        private bool IsGameClose()
         {
             foreach (var currentcasket in _casket)
             {
                 if (currentcasket == CasketStatus.Empty)
                 {
                     return false;
                 }
             }            
         }
         

            private void StartNewGame()
        {
            CasketEmpty();

            isFirstPlayer = true;
            _isGameClose = false;

        }
        public void CasketEmpty()
        {
            _casket = new CasketStatus[9];
            for (int i = 0; i < _casket.Length -1; i++)
            {
                _casket[i] = CasketStatus.Empty;
            }

            bt1_0_0.Content = string.Empty;
            bt2_0_1.Content = string.Empty;
            bt3_0_2.Content = string.Empty;

            bt1_0_0.Background = (Brush)new BrushConverter().ConvertFrom("#14c600");
            bt2_0_1.Background = (Brush)new BrushConverter().ConvertFrom("#14c600");
            bt3_0_2.Background = (Brush)new BrushConverter().ConvertFrom("#14c600");

            bt1_0_0.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
            bt2_0_1.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
            bt3_0_2.Foreground = (Brush)new BrushConverter().ConvertFrom("#F9F2E7");
        }        
    }
}
