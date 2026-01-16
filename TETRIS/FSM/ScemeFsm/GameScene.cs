using System.Drawing;

namespace MyApp.FSM;

public class GameScene(SceneManager fsm) : SceneFsm(fsm)
{
    public int [] map = new int[3];
    public override void Enter()
    {
        Console.Clear();
        for (int i = 0; i < 20; ++i)
        {
            Console.WriteLine($"▣▣▣▣▣▣▣▣▣▣▣▣");
        }
        Console.WriteLine($"▇▇▇▇▇▇▇▇▇▇");
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine($"ABCDEFGHIJKLNM");
        Console.ResetColor();

    }

    public override void Update(ConsoleKeyInfo? keyInfo)
    {
    }

    protected override void Render()
    {
    }

    public override void Exit()
    {
    }
    // Console.WriteLine($"▣▣▣▣▣▣");
    // Console.WriteLine($"▇▇▇▇▇▇");
}