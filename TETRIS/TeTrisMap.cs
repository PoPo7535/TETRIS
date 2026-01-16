namespace MyApp;

public class TeTrisMap
{
    private readonly TetrisColor[,] _map = new TetrisColor[20, 10];
    private TetrisColor _saveBlock = TetrisColor.None;
    private TetrisColor[] _nextBlock = new TetrisColor[4];
    private readonly (int y, int x) renderOff = (1, 1);
    private string[] mapString =
    [
        "█-Save-████████████-Next-█",
        "█      █          █      █",
        "█      █          █      █",
        "█      █          █      █",
        "█      █          █      █  Level : 0",
        "████████          ████████  Score : 0",
        "       █          █      █",
        "       █          █      █",
        "       █          █      █",
        "       █          █      █",
        "       █          ████████",
        "       █          █      █",
        "       █          █      █",
        "       █          █      █",
        "       █          █      █",
        "       █          ████████",
        "       █          █      █",
        "       █          █      █",
        "       █          █      █",
        "       █          █      █",
        "       █          ████████",
        "       █          █",
        "       █          █",
        "       █          █",
        "       ████████████",
    ];
    public void Map()
    {
        for (int y = 0; y < mapString.Length; y++)
        {
            for (int x = 0; x < mapString[y].Length; x++)
            {
                if(' ' == mapString[y][x])
                    continue;
                ConsoleHelper.Write(mapString[y][x],x,y);
            }
        }
    }
}