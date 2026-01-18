namespace MyApp;

public static class GameManager
{
    public static bool isRunning = true;
    public const int TargetFps = 60;
    public const int FrameTimeMs = 1000 / TargetFps;
}