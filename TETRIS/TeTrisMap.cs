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
        for (int i = 0; i < mapString.Length; i++)
        {
            for (int j = 0; j < mapString[i].Length; j++)
            {
                ConsoleHelper.Write(mapString[i][j],j,i);
            }
            ConsoleHelper.Write('n');
        }
    }
}