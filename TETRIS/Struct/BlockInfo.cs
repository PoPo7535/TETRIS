namespace MyApp;

public struct BlockInfo(BlockType type, TetrisColor color, string[][] allShape)
{
    public TetrisColor color = color;
    public BlockType type = type;
    private string[][] allShape = allShape;
    public string[] shape => allShape[shapeIndex];
    public string[] firstShape => allShape[0];
    public string[] rotationShape => allShape[GetNextIndex()];

    private int shapeIndex = 0;

    private int GetNextIndex()
    {
        var nextIndex = shapeIndex + 1;
        return nextIndex == allShape.Length ? 0 : nextIndex;
    }

    public void RotationShape()
    {
        ++shapeIndex;
        if (shapeIndex == allShape.Length)
            shapeIndex = 0;
        ConsoleHelper.Write(shapeIndex.ToString(), 0, 2);
    }
    public void InitIndex()
    {
        shapeIndex = 0;
    }
}