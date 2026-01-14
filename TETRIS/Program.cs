using System;
using System.Drawing;
using System.Text;


namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            ConsoleHelper.Write("A", ColorType.Blue);
            ConsoleHelper.Write("A", ColorType.Pink);
            ConsoleHelper.Write("A", ColorType.Red);
            ConsoleHelper.Flush();
        }
    }
}

// var sr = new StreamReader(Console.OpenStandardInput());
// var sw = new StreamWriter(Console.OpenStandardOutput());
// sr.Close();
// sw.Close();