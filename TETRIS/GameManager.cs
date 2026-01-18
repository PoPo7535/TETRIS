using MyApp.FSM;

namespace MyApp;

public static class GameManager
{
    static GameManager()
    {
        for (int i = 1; i <= 11; i++)
        {
            levelDic.Add(i, new LevelInfo()
            {
                level = i,
                fallTick = i * 5,
                levelUpScore = 200 * i,
                personalColor = "",
            });
        }

        levelDic.Add(12, new LevelInfo()
        {
            level = 12,
            fallTick = 58,
            levelUpScore = int.MaxValue,
            personalColor = "",
        });
    }

    public static LevelInfo GetLevelInfo(int level)
    {
        return levelDic[level];
    }
    private static Dictionary<int, LevelInfo> levelDic = new();
    public static bool isRunning = true;
    public const int TargetFps = 60;
    public const int FrameTimeMs = 1000 / TargetFps;

    public static readonly int DropScore = 10;
    public static readonly int LineClearScore = 100;
    
    
}