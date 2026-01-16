using System.Drawing;

namespace MyApp.FSM;

public class Game(SceneManager fsm) : Fsm(fsm)
{
    private TeTrisMap _map = new();
    public override void Enter()
    {
        _map.Map();
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