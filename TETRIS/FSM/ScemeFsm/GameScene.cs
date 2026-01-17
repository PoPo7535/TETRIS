using System.Drawing;

namespace MyApp.FSM;

public class GameScene(SceneManager fsm) : Fsm(fsm)
{
    private readonly TeTrisMap _map = new();
    public override void Enter()
    {
        _map.Init();
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
}