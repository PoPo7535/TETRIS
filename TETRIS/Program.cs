using System;
using System.Drawing;
using System.Text;
using MyApp.FSM;


namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            IGameStep title = new MainTitle();

            title.Enter();




            Console.WriteLine($"▣▣▣▣▣▣▣▣▣▣▣▣");
            Console.WriteLine($"▣▣▣▣▣▣▣▣▣▣▣▣");
        }

        void GameLoop()
        {
        }
    }
}

// var sr = new StreamReader(Console.OpenStandardInput());
// var sw = new StreamWriter(Console.OpenStandardOutput());
// sr.Close();
// sw.Close();