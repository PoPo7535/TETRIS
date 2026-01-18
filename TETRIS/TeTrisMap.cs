using Microsoft.VisualBasic;

namespace MyApp;

public class TeTrisMap
{
    private readonly TetrisColor[,] _map = new TetrisColor[20, 10];
    private BlockInfo _holdBlock;
    private readonly BlockInfo[] _nextBlock = new BlockInfo[4];
    private BlockInfo _handleBlock;
    private (BlockType type, int probability)[] _typeProbability;
    private readonly Random _random = new();
    private readonly (int x, int y) _renderOff = (5, 0);
    private (int x, int y) HoldPos => (2 + _renderOff.x, 2 + _renderOff.y);
    private (int x, int y) NextPos => (20 + _renderOff.x, 2 + _renderOff.y);
    private (int x, int y) LevelPos => (36 + _renderOff.x, 4 + _renderOff.y);
    private (int x, int y) ScorePos => (36 + _renderOff.x, 5 + _renderOff.y);
    private (int x, int y) _handelBlockPos = (0, 0);
    private (int x, int y) HandelBlockStartPos => (_renderOff.x + 11, 1);

    public void Init()
    {
        for (int y = 0; y < Strings.Map.Length; y++)
        {
            for (int x = 0; x < Strings.Map[y].Length; x++)
            {
                if (' ' == Strings.Map[y][x])
                    continue;
                ConsoleHelper.Write(Strings.Map[y][x], x + _renderOff.x, y + _renderOff.y);
            }
        }

        _typeProbability =
        [
            (BlockType.I, 1),
            (BlockType.O, 1),
            (BlockType.Z, 1),
            (BlockType.S, 1),
            (BlockType.J, 1),
            (BlockType.L, 1),
            (BlockType.T, 1),
        ];

        for (int i = 0; i < _nextBlock.Length; ++i)
            SetNextBlock(i, GetRandomBlockType());
        SetHandleBlockFromNextBlock();
    }

    public BlockType GetRandomBlockType()
    {
        var sum = 0;
        for (int i = 0; i < _typeProbability.Length; i++)
            sum += _typeProbability[i].probability;

        var randomValue = _random.Next(0, sum);
        sum = 0;
        for (int i = 0; i < _typeProbability.Length; i++)
        {
            sum += _typeProbability[i].probability;

            if (randomValue <= sum)
            {
                _typeProbability[i].probability = 0;

                for (int j = 0; j < _typeProbability.Length; j++)
                    ++_typeProbability[j].probability;
                return _typeProbability[i].type;
            }
        }

        return BlockType.I;
    }

    public void SetNextBlock(int index, BlockType blockType)
    {
        var offY = NextPos.y + (index * 5);
        var blockInfo = Strings.BlockInfo[blockType];
        _nextBlock[index] = blockInfo;
        SetBlock(blockInfo.shape, NextPos.x, offY, blockInfo.color);
    }

    public void SwapBlock()
    {
        (_handleBlock, _holdBlock) = (_holdBlock, _handleBlock);
        SetBlock(_holdBlock.shape, HoldPos.x, HoldPos.y, _holdBlock.color);
        SetBlock(_handleBlock.shape, HandelBlockStartPos.x, HandelBlockStartPos.y, _handleBlock.color);
    }

    private void SetBlock(string[] shape, int xPos, int yPos, TetrisColor tetrisColor)
    {
        ConsoleHelper.Write("    ", xPos, yPos);
        ConsoleHelper.Write("    ", xPos, yPos + 1);
        ConsoleHelper.Write(shape[0], xPos, yPos, tetrisColor);
        ConsoleHelper.Write(shape[1], xPos, yPos + 1, tetrisColor);
    }

    public void SetHandleBlockFromNextBlock()
    {
        _handleBlock = _nextBlock[0];
        _handelBlockPos = HandelBlockStartPos;
        SetBlock(_handleBlock.shape, HandelBlockStartPos.x, HandelBlockStartPos.y, _handleBlock.color);
        for (int i = 0; i < _nextBlock.Length; ++i)
        {
            if (i < _nextBlock.Length - 1)
                SetNextBlock(i, _nextBlock[i + 1].type);
            else
                SetNextBlock(i, GetRandomBlockType());
        }
    }

    public void SetLevel(int level)
    {
        ConsoleHelper.Write(level.ToString(), LevelPos);
    }

    public void SetScore(int score)
    {
        ConsoleHelper.Write(score.ToString(), ScorePos);
    }

    public void ClearLine()
    {
    }

    public void Control(ConsoleKeyInfo? keyInfo)
    {
        if (keyInfo == null)
            return;
        if ((keyInfo.Value.Modifiers & ConsoleModifiers.Shift) != 0)
        {
        }


        switch (keyInfo.Value.Key)
        {
            case ConsoleKey.LeftArrow:
                TryHandleBlockMove((_handelBlockPos.x - 1, _handelBlockPos.y));
                break;
            case ConsoleKey.RightArrow:
                TryHandleBlockMove((_handelBlockPos.x + 1, _handelBlockPos.y));
                break;
            case ConsoleKey.DownArrow:
                TryHandleBlockMove((_handelBlockPos.x, _handelBlockPos.y + 1));
                break;
            case ConsoleKey.UpArrow:
                TryHandleBlockRotationBlock();
                break;
            case ConsoleKey.Spacebar:
                DropBlock();
                break;
        }
    }

    private void TryHandleBlockMove((int x, int y) movePos)
    {
        ClearHandleBlock(_handelBlockPos);
        DrawHandleBlock(movePos);
    }

    private void TryHandleBlockRotationBlock()
    {
    }

    private void DrawHandleBlock((int x, int y) pos)
    {
        for (int y = 0; y < _handleBlock.shape.Length; ++y)
        {
            for (int x = 0; x < _handleBlock.shape[y].Length; ++x)
            {
                if(_handleBlock.shape[y][x] == ' ' )
                    continue;
                ConsoleHelper.Write('□', pos.x + x, pos.y + y, _handleBlock.color);
            }
        }
        _handelBlockPos = pos;
    }

    private void ClearHandleBlock((int x, int y) pos)
    {
        for (int y = 0; y < _handleBlock.shape.Length; ++y)
        {
            for (int x = 0; x < _handleBlock.shape[y].Length; ++x)
            {
                if(_handleBlock.shape[y][x] == ' ' )
                    continue;
                ConsoleHelper.Write(' ', pos.x + x, pos.y + y);
            }
        }
    }

    private void DropBlock()
    {
        
    }
    public void NextTick()
    {
        
    }
}