namespace MyApp;

public struct BlockInfo(BlockType type, TetrisColor color)
{
    public TetrisColor color = color;
    public BlockType type = type;
    public string[] shape;
}