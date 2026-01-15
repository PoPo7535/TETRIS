using System.Text;

namespace MyApp;

public static class ConsoleHelper
{
    static Dictionary<TetrisColor, string> colors = new();

    static ConsoleHelper()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.SetWindowSize(100,20);
        Console.CursorVisible = false;
        colors.Add(TetrisColor.Red, "\e[38;2;255;60;60m");
        colors.Add(TetrisColor.Pink, "\e[38;2;255;105;180m");
        colors.Add(TetrisColor.Orange, "\e[38;2;255;165;0m");
        colors.Add(TetrisColor.Yellow, "\e[38;2;255;255;0m");
        colors.Add(TetrisColor.Green, "\e[38;2;120;255;120m");
        colors.Add(TetrisColor.Blue, "\e[38;2;0;128;255m");
        colors.Add(TetrisColor.Purple, "\e[38;2;160;64;160m");
    }


    public static void Write(string str)
        => Console.Write(str);

    public static void Write(char str)
        => Console.Write(str);
    public static void Write(string str, int left, int top)
    {
        var cursorBuffer = Console.GetCursorPosition();
        Console.SetCursorPosition(left, top);
        Console.Write($"{str}\n");
        Console.SetCursorPosition(cursorBuffer.Left, cursorBuffer.Top);
    }

    public static void Write(string str, TetrisColor tetrisColor)
        => Console.Write($"{colors[tetrisColor]}{str}\e[0m");

    public static void WriteLine(string str) =>
        Console.Write($"{str}\n");
    public static void WriteLine(string str, int left, int top)
    {
        var cursorBuffer = Console.GetCursorPosition();
        Console.SetCursorPosition(left, top);
        Console.Write($"{str}\n");
        Console.SetCursorPosition(cursorBuffer.Left, cursorBuffer.Top);
    }

public static void WriteLine(string str, TetrisColor tetrisColor) 
        => Console.Write($"{colors[tetrisColor]}{str}\e[0m\n");


}