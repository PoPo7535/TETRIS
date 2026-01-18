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
    private (int x, int y) _preivousPredictionPos;
    private LevelInfo _currentLevel;
    private int _fpsCounter;
    public int score = 0;
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

        score = 0;
        AddScore(0);
        SetLevel(1);
    }

    private BlockType GetRandomBlockType()
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

    private void SetNextBlock(int index, BlockType blockType)
    {
        var offY = NextPos.y + (index * 5);
        var blockInfo = Strings.BlockInfo[blockType];
        _nextBlock[index] = blockInfo;
        DrawBlock(blockInfo, NextPos.x, offY);
    }

    private void SwapBlock()
    {
        ClearHandleBlock(_handleBlock.shape, _preivousPredictionPos);
        ClearHandleBlock(_handleBlock.shape, _handleBlockPos);
        if (_holdBlock != null)
        {
            (_handleBlock, _holdBlock) = (_holdBlock.Value, _handleBlock);
            _handleBlock.InitIndex();
            _holdBlock.Value.InitIndex();
            DrawBlock(_handleBlock, HandelBlockStartPos.x, HandelBlockStartPos.y);
            DrawBlock(_holdBlock.Value, HoldPos.x, HoldPos.y);
        }
        else
        {
            _holdBlock = _handleBlock;
            _handleBlock.InitIndex();
            _holdBlock.Value.InitIndex();
            DrawBlock(_holdBlock.Value, HoldPos.x, HoldPos.y);
            SetHandleBlockFromNextBlock();
        }
        _preivousPredictionPos = GetBottomPos(HandelBlockStartPos);
        DrawHandleBlock(_handleBlock.shape, _preivousPredictionPos, _handleBlock.color, '□');


        _handleBlockPos = HandelBlockStartPos;
    }

    private void DrawBlock(BlockInfo info, int xPos, int yPos)
    {
        ConsoleHelper.Write("    ", xPos, yPos);
        ConsoleHelper.Write("    ", xPos, yPos + 1);
        ConsoleHelper.Write(info.firstShape[0], xPos, yPos, info.color);
        ConsoleHelper.Write(info.firstShape[1], xPos, yPos + 1, info.color);
    }

    private (int, int) GetBottomPos((int x, int y) pos)
    {
        for (int mapY = pos.y; mapY < 23; mapY++)
        {
            if (false == CanHandleBlockMove((pos.x, mapY)))
                return (pos.x, mapY - 1);
        }
        return (pos.x, 22);
    }

    private void SetHandleBlockFromNextBlock()
    {
        End();
        _handleBlock = _nextBlock[0];
        _handleBlockPos = HandelBlockStartPos;
        _preivousPredictionPos = GetBottomPos(_handleBlockPos);
        DrawHandleBlock(_handleBlock.shape, _preivousPredictionPos, _handleBlock.color, '□');
        DrawBlock(_handleBlock, HandelBlockStartPos.x, HandelBlockStartPos.y);
        for (int i = 0; i < _nextBlock.Length; ++i)
        {
            if (i < _nextBlock.Length - 1)
                SetNextBlock(i, _nextBlock[i + 1].type);
            else
                SetNextBlock(i, GetRandomBlockType());
        }
    }

    private void SetLevel(int level)
    {
        _currentLevel = GameManager.GetLevelInfo(level);
        ConsoleHelper.Write(_currentLevel.level.ToString(), LevelPos);
    }

    private void AddScore(int score)
    {
        this.score += score;
        if (_currentLevel.levelUpScore < this.score)
            SetLevel(_currentLevel.level + 1);
        ConsoleHelper.Write(this.score.ToString(), ScorePos);
    }

    public void Update(ConsoleKeyInfo? keyInfo)
    {
        ++_fpsCounter;
        if (GameManager.TargetFps - _currentLevel.fallTick < _fpsCounter)
        {
            TryHandleBlockDown();
        }

        Control(keyInfo);
    }

    private void TryHandleBlockDown()
    {
        _fpsCounter = 0;
        var success = TryHandleBlockMove((_handleBlockPos.x, _handleBlockPos.y + 1));
        if (false == success)
        {
            _preivousPredictionPos = (0, 0);
            SetBlock();
            SetHandleBlockFromNextBlock();
            TryClearLine();
        }
    }

    private void TryClearLine()
    {
        var count = 0;
        for (int y = 22; y >= 0; y--)
        {
            var lineClear = true;
            for (int x = 0; x < 10; ++x)
            {
                if (_map[y, x] == TetrisColor.None)
                {
                    lineClear = false;
                    break;
                }
            }

            if (lineClear)
            {
                ++count;
                for (int x = 0; x < 10; ++x)
                {
                    _map[y, x] = TetrisColor.None;
                    ConsoleHelper.Write(' ', _mapStartPos.x + x, _mapStartPos.y + y);
                }
            }
            else
            {
                if (count == 0)
                    continue;
                for (int x = 0; x < 10; ++x)
                {
                    var color = _map[y, x];
                    _map[y, x] = TetrisColor.None;
                    ConsoleHelper.Write(color == TetrisColor.None
                            ? ' '
                            : '▣',
                        _mapStartPos.x + x,
                        _mapStartPos.y + y + count, color);
                    _map[y + count, x] = color;
                }
            }
        }

        AddScore(count * GameManager.LineClearScore);
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
        AddScore(GameManager.DropScore);
    }

    private bool TryHandleBlockMove((int x, int y) movePos)
    {
        if (false == CanHandleBlockMove(movePos))
            return false;
        DrawPredictionBlock(movePos);
        ClearHandleBlock(_handleBlock.shape, _handleBlockPos);
        DrawHandleBlock(_handleBlock.shape, movePos, _handleBlock.color);
        _handleBlockPos = movePos;
        return true;
       
    }

    private void DrawPredictionBlock((int x, int y) pos)
    {
        ClearHandleBlock(_handleBlock.shape, _preivousPredictionPos);
        _preivousPredictionPos = GetBottomPos(pos);
        DrawHandleBlock(_handleBlock.shape, _preivousPredictionPos, _handleBlock.color, '□');
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

    private void TryHandleBlockRotation()
    {
        if (false == CanHandleBlockRotation()) return;
        ClearHandleBlock(_handleBlock.shape, _handleBlockPos);
        ClearHandleBlock(_handleBlock.shape, _preivousPredictionPos);
        _handleBlock.RotationShape();
        _preivousPredictionPos = GetBottomPos(_handleBlockPos);
        DrawHandleBlock(_handleBlock.shape, _preivousPredictionPos, _handleBlock.color, '□');
        DrawHandleBlock(_handleBlock.shape, _handleBlockPos, _handleBlock.color);
        return;
        bool CanHandleBlockRotation()
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
    }

    private void DrawHandleBlock(string[] shape, (int x, int y) pos, TetrisColor color, char ch = '▣')
    {
        for (int y = 0; y < shape.Length; ++y)
        {
            for (int x = 0; x < shape[y].Length; ++x)
            {
                if (shape[y][x] == ' ')
                    continue;
                if(pos.y + y == 0)
                    continue;
                ConsoleHelper.Write(ch, pos.x + x, pos.y + y, color);
            }
        }

    }

    private void ClearHandleBlock(string[] shape ,(int x, int y) pos)
    {
        for (int y = 0; y < shape.Length; ++y)
        {
            for (int x = 0; x < shape[y].Length; ++x)
            {
                if (shape[y][x] == ' ')
                    continue;
                ConsoleHelper.Write(' ', pos.x + x, pos.y + y);
            }
        }
    }


    private void DropBlock()
    {
        // _preivousPredictionPos = (0, 0);
        ClearHandleBlock(_handleBlock.shape, _handleBlockPos);
        _handleBlockPos = GetBottomPos(_handleBlockPos);
        DrawHandleBlock(_handleBlock.shape, _handleBlockPos, _handleBlock.color);
        
        SetBlock();
        SetHandleBlockFromNextBlock();
        TryClearLine();
        _fpsCounter = 0;
    }

    private void End()
    {
        for (int y = 0; y < 2; ++y)
        {
            for (int x = 0; x < 4; ++x)
            {
                if (_map[y, x + 3] != TetrisColor.None)
                { 
                    GameManager.isRunning = false;
                    ConsoleHelper.Write("Game Over",  ScorePos.x- 7, ScorePos.y + 3, TetrisColor.Red);
                }
            }
        }
    }
}