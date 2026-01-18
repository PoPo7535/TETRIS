using MyApp.FSM;
namespace MyApp
{
    internal static class Program
    {
        private static SceneManager SceneManager;

        private static void Main()
        {
            SceneManager = new SceneManager();
            GameLoop();
        }

        private static void GameLoop()
        {
            while (GameManager.isRunning)
            {
                var start = DateTime.Now;

                SceneManager.Update(GetKeyInput());

                var elapsed = (DateTime.Now - start).TotalMilliseconds;
                var sleepTime = Math.Max(0, GameManager.FrameTimeMs - (int)elapsed);
                Thread.Sleep(sleepTime);
            }
        }

        private static ConsoleKeyInfo? GetKeyInput()
        {
            if (Console.KeyAvailable)
                return Console.ReadKey(true);
            return null;
        }
    }
}
