using System.Text;

namespace MyApp;

public static class ConsoleHelper
{
    static Dictionary<ColorType,string> colors = new();
    static StreamReader sr;
    static StreamWriter sw;
    static ConsoleHelper()
    {
        Console.OutputEncoding = Encoding.UTF8;
        sr = new StreamReader(Console.OpenStandardInput());
        sw =  new StreamWriter(Console.OpenStandardOutput());;
        colors.Add(ColorType.Red,    "\e[38;2;255;60;60m");  
        colors.Add(ColorType.Pink,   "\e[38;2;255;105;180m");
        colors.Add(ColorType.Orange, "\e[38;2;255;165;0m");  
        colors.Add(ColorType.Yellow, "\e[38;2;255;255;0m");  
        colors.Add(ColorType.Green,  "\e[38;2;120;255;120m");
        colors.Add(ColorType.Blue,   "\e[38;2;0;128;255m");  
        colors.Add(ColorType.Purple, "\e[38;2;160;64;160m"); 
    }

    public static void Flush() 
        => sw.Flush();

    public static void Write(string str, ColorType colorType)
        => sw.Write($"{colors[colorType]}{str}\e[0m");

    public static void Write(string str)
        => sw.Write(str);

    public static void WriteLine(string str, ColorType colorType) 
        => sw.Write($"{colors[colorType]}{str}\e[0m\n");

    public static void WriteLine(string str)
        => sw.Write($"{str}\n");

}