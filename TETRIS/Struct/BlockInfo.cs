namespace MyApp;

public struct BlockInfo(BlockType type, TetrisColor color, string[][] shape)
{
    public TetrisColor color = color;
    public BlockType type = type;
    public string[][] shape = shape;
}