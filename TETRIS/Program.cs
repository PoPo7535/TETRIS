using MyApp.FSM;
namespace MyApp
{
    internal static class Program
    {
        private static GameStepFSM fsm = new();

        private static void Main()
        {
            GameLoop();
        }

        private static void GameLoop()
        {
            const int targetFps = 1;
            const int frameTimeMs = 1000 / targetFps; // 약 16ms

            while (GameManager.isRunning)
            {
                var start = DateTime.Now;

                fsm.Update(GetKeyInput());

                var elapsed = (DateTime.Now - start).TotalMilliseconds;
                var sleepTime = Math.Max(0, frameTimeMs - (int)elapsed);
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

// var sr = new StreamReader(Console.OpenStandardInput());
// var sw = new StreamWriter(Console.OpenStandardOutput());
// sr.Close();
// sw.Close();