namespace MyApp.FSM;

public class MainTitle(GameStepFSM fsm) : GameStep(fsm)
{
    public override void Enter()
    {
        ConsoleHelper.Write('\n');
        foreach (var t in logo)
        {
            for (int cal = 0; cal < t.Length; ++cal)
            {
                ConsoleHelper.Write(t[cal], logoColor[cal]);
            }

            ConsoleHelper.Write('\n');
        }

        ConsoleHelper.Write('\n');
        ConsoleHelper.WriteLine("⇧  :".PadLeft(7) + " 블럭 회전", 14, 10);
        ConsoleHelper.WriteLine("⇦⇩⇨ :".PadLeft(7) + " 블럭 이동", 14, 11);
        ConsoleHelper.WriteLine("Space :".PadLeft(5) + " 블럭 설치", 14, 12);
        ConsoleHelper.WriteLine("Shift :".PadLeft(5) + " 블럭 저장\n", 14, 13);
        ConsoleHelper.WriteLine("아무키를 눌러 시작해 주세요", 10, 14);
    }

    public override void Update(ConsoleKeyInfo? keyInfo)
    {
        if (keyInfo == null)
            return;
        fsm.ChangeStep(GameStepFSM.EGameStep.GameScene);
    }

    protected override void Render()
    {
    }

    public override void Exit()
    {
    }

    private TetrisColor[] logoColor =
    [
        TetrisColor.Red,
        TetrisColor.Orange,
        TetrisColor.Yellow,
        TetrisColor.Green,
        TetrisColor.Blue,
        TetrisColor.Purple
    ];

    private string[][] logo = new string[][]
    {
        ["████████╗", "███████╗", "████████╗", "██████╗ ", "██╗", " ██████╗"],
        ["╚══██╔══╝", "██╔════╝", "╚══██╔══╝", "██╔══██╗", "██║", "██╔════╝"],
        ["   ██║   ", "█████╗  ", "   ██║   ", "██████╔╝", "██║", "╚█████╗ "],
        ["   ██║   ", "██╔══╝  ", "   ██║   ", "██╔══██╗", "██║", " ╚═══██╗"],
        ["   ██║   ", "███████╗", "   ██║   ", "██║  ██║", "██║", "██████╔╝"],
        ["   ╚═╝   ", "╚══════╝", "   ╚═╝   ", "╚═╝  ╚═╝", "╚═╝", "╚═════╝ "],
    };
}