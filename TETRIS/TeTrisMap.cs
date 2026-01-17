namespace MyApp;

public class TeTrisMap
{
    private readonly TetrisColor[,] _map = new TetrisColor[20, 10];
    private TetrisColor _saveBlock = TetrisColor.None;
    private TetrisColor[] _nextBlock = new TetrisColor[4];
    private readonly (int x, int y) _renderOff = (5,0);
    private (int x, int y) SavePos => (2 + _renderOff.x, 2 + _renderOff.y);
    private (int x, int y) NextPos => (20 + _renderOff.x, 2 + _renderOff.y);
    private (int x, int y) LevelPos => (36 + _renderOff.x, 4 + _renderOff.y);
    private (int x, int y) ScorePos => (36 + _renderOff.x, 5 + _renderOff.y);
    
    public void Map()
    {
        for (int y = 0; y < Strings.Map.Length; y++)
        {
            for (int x = 0; x < Strings.Map[y].Length; x++)
            {
                if(' ' == Strings.Map[y][x])
                    continue;
                ConsoleHelper.Write(Strings.Map[y][x], x + _renderOff.x, y + _renderOff.y);
            }

            ConsoleHelper.Write("1", SavePos);
            ConsoleHelper.Write("2", NextPos);
            ConsoleHelper.Write("3", ScorePos);
            ConsoleHelper.Write("4", LevelPos);
        }
    }
}