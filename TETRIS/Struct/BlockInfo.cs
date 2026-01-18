namespace MyApp;

public struct BlockInfo(BlockType type, TetrisColor color, string[][] allShape)
{
    public TetrisColor color = color;
    public BlockType type = type;
    private string[][] allShape = allShape;
    public string[] shape => allShape[shapeIndex];
    public string[] rotationShape => allShape[GetNextIndex()];

    private int shapeIndex = 0;

    private int GetNextIndex()
    {
        var nextIndex = shapeIndex + 1;
        return nextIndex == shape.Length ? 0 : nextIndex;
    }

    private void RotationShape()
    {
        ++shapeIndex;
        if (shapeIndex == shape.Length)
            shapeIndex = 0;
    }
}