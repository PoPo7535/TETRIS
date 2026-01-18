using Microsoft.VisualBasic;

namespace MyApp;

public class TeTrisMap
{
    private readonly TetrisColor[,] _map = new TetrisColor[23, 10];
    private BlockInfo? _holdBlock;
    private BlockInfo _handleBlock;
    private readonly BlockInfo[] _nextBlock = new BlockInfo[4];
    private (BlockType type, int probability)[] _typeProbability;
    private readonly Random _random = new();

    private int fpsCounter = 0;

    private (int x, int y) _handleBlockPos = (0, 0);
    private readonly (int x, int y) _renderOff = (5, 0);
    private readonly (int x, int y) _mapStartPos = (13, 1);
    private (int x, int y) HoldPos => (2 + _renderOff.x, 2 + _renderOff.y);
    private (int x, int y) NextPos => (20 + _renderOff.x, 2 + _renderOff.y);
    private (int x, int y) LevelPos => (36 + _renderOff.x, 4 + _renderOff.y);
    private (int x, int y) ScorePos => (36 + _renderOff.x, 5 + _renderOff.y);
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
        DrawBlock(blockInfo.shape, NextPos.x, offY, blockInfo.color);
    }

    public void SwapBlock()
    {
        ClearHandleBlock(_handleBlockPos);
        if (_holdBlock != null)
        {
            (_handleBlock, _holdBlock) = (_holdBlock.Value, _handleBlock);
            DrawBlock(_handleBlock.shape, HandelBlockStartPos.x, HandelBlockStartPos.y, _handleBlock.color);
            DrawBlock(_holdBlock.Value.shape, HoldPos.x, HoldPos.y, _holdBlock.Value.color);
        }
        else
        {
            _holdBlock = _handleBlock;
            DrawBlock(_handleBlock.shape, HoldPos.x, HoldPos.y, _handleBlock.color);
            SetHandleBlockFromNextBlock();
        }

        _handleBlockPos = HandelBlockStartPos;
    }

    private void DrawBlock(string[] shape, int xPos, int yPos, TetrisColor tetrisColor)
    {
        ConsoleHelper.Write("    ", xPos, yPos);
        ConsoleHelper.Write("    ", xPos, yPos + 1);
        ConsoleHelper.Write(shape[0], xPos, yPos, tetrisColor);
        ConsoleHelper.Write(shape[1], xPos, yPos + 1, tetrisColor);
    }

    public void SetHandleBlockFromNextBlock()
    {
        _handleBlock = _nextBlock[0];
        _handleBlockPos = HandelBlockStartPos;
        DrawBlock(_handleBlock.shape, HandelBlockStartPos.x, HandelBlockStartPos.y, _handleBlock.color);
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

    public void Update(ConsoleKeyInfo? keyInfo)
    {
        ++fpsCounter;
        if (GameManager.TargetFps -30< fpsCounter)
        {
            TryHandleBlockDown();
        }

        Control(keyInfo);
    }

    private void TryHandleBlockDown()
    {
        fpsCounter = 0;
        var success = TryHandleBlockMove((_handleBlockPos.x, _handleBlockPos.y + 1));
        if (false == success)
        {
            SetBlock();
            SetHandleBlockFromNextBlock();
        }
    }
    private void Control(ConsoleKeyInfo? keyInfo)
    {
        if (keyInfo == null)
            return;

        switch (keyInfo.Value.Key)
        {
            case ConsoleKey.LeftArrow:
                TryHandleBlockMove((_handleBlockPos.x - 1, _handleBlockPos.y));
                break;
            case ConsoleKey.RightArrow:
                TryHandleBlockMove((_handleBlockPos.x + 1, _handleBlockPos.y));
                break;
            case ConsoleKey.DownArrow:
                TryHandleBlockDown();
                break;
            case ConsoleKey.UpArrow:
                TryHandleBlockRotation();
                break;
            case ConsoleKey.Spacebar:
                DropBlock();
                break;
            case ConsoleKey.C:
                SwapBlock();
                break;
        }
    }

    private void SetBlock()
    {
        for (int y = 0; y < _handleBlock.shape.Length; ++y)
        {
            for (int x = 0; x < _handleBlock.shape[y].Length; ++x)
            {
                if (_handleBlock.shape[y][x] == ' ')
                    continue;
                var xPos = _handleBlockPos.x + x - _mapStartPos.x;
                var yPos = _handleBlockPos.y + y - 1;
                _map[yPos, xPos] = _handleBlock.color;
            }
        }
    }

    private bool TryHandleBlockMove((int x, int y) movePos)
    {
        if (false == CanHandleBlockMove(movePos))
            return false;
        ClearHandleBlock(_handleBlockPos);
        DrawHandleBlock(movePos);
        return true;
    }

    private bool TryHandleBlockRotation()
    {
        if (false == CanHandleBlockRotation())
            return false;
        ClearHandleBlock(_handleBlockPos);
        _handleBlock.RotationShape();
        DrawHandleBlock(_handleBlockPos);
        return true;
    }

    private bool CanHandleBlockRotation()
    {
        for (int y = 0; y < _handleBlock.rotationShape.Length; ++y)
        {
            for (int x = 0; x < _handleBlock.rotationShape[y].Length; ++x)
            {
                if (_handleBlock.rotationShape[y][x] == ' ')
                    continue;
                var xPos = _handleBlockPos.x + x - _mapStartPos.x;
                if (xPos < 0 || 10 <= xPos)
                    return false;
                if (Strings.Map.Length - 2 < _handleBlockPos.y + y)
                    return false;
                if (_map[_handleBlockPos.y + y - 1, xPos] != TetrisColor.None)
                    return false;
            }
        }

        return true;
    }

    private void DrawHandleBlock((int x, int y) pos)
    {
        for (int y = 0; y < _handleBlock.shape.Length; ++y)
        {
            for (int x = 0; x < _handleBlock.shape[y].Length; ++x)
            {
                if (_handleBlock.shape[y][x] == ' ')
                    continue;
                ConsoleHelper.Write(_handleBlock.shape[y][x], pos.x + x, pos.y + y, _handleBlock.color);
            }
        }

        _handleBlockPos = pos;
    }

    private void ClearHandleBlock((int x, int y) pos)
    {
        for (int y = 0; y < _handleBlock.shape.Length; ++y)
        {
            for (int x = 0; x < _handleBlock.shape[y].Length; ++x)
            {
                if (_handleBlock.shape[y][x] == ' ')
                    continue;
                ConsoleHelper.Write(' ', pos.x + x, pos.y + y);
            }
        }
    }

    private bool CanHandleBlockMove((int x, int y) pos)
    {
        for (int y = 0; y < _handleBlock.shape.Length; ++y)
        {
            for (int x = 0; x < _handleBlock.shape[y].Length; ++x)
            {
                if (_handleBlock.shape[y][x] == ' ')
                    continue;
                var xPos = pos.x + x - _mapStartPos.x;
                if (xPos < 0 || 10 <= xPos)
                    return false;
                if (Strings.Map.Length - 2 < pos.y + y)
                    return false;
                if (_map[pos.y + y - 1, xPos] != TetrisColor.None)
                    return false;
            }
        }

        return true;
    }

    private void DropBlock()
    {
    }
}