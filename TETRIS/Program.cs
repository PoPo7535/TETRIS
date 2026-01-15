using MyApp.FSM;
namespace MyApp
{
    internal class Program
    {
        private static GameStepFSM fsm = new();
        static void Main()
        {
            var gameLoopThread = new Thread(GameLoop);
            gameLoopThread.Start();

            
            gameLoopThread.Join();

            // Console.WriteLine($"▣▣▣▣▣▣▣▣▣▣▣▣");
            // Console.WriteLine($"▣▣▣▣▣▣▣▣▣▣▣▣");
        }

        static void GameLoop()
        {
            const int targetFps = 60;
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
                return Console.ReadKey(true); // 입력 있음 → 키 반환
            return null; // 입력 없음 → null 반환
        }
    }
}

// var sr = new StreamReader(Console.OpenStandardInput());
// var sw = new StreamWriter(Console.OpenStandardOutput());
// sr.Close();
// sw.Close();