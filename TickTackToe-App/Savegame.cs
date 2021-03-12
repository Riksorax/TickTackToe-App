using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TickTackToe_App
{
    class Savegame : MainWindow
    {
        public void SaveGame()
        {
            string path = @"C:\Users\Frank\Documents\Programieren\C#\TIckTackToe-App\TickTackToe-App\TickTackToe-App\temp\TestSpeicher.txt";

            if (File.Exists(path))
            {
                using StreamWriter sw = File.CreateText(path);
                sw.WriteLine(lb_Player1.Content);
                sw.WriteLine(lb_Player2.Content);
                sw.WriteLine(lb_Points1.Content);
                sw.WriteLine(lb_Points2.Content);
            }

        }
    }
}
