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
        _map.Update(keyInfo);
    }

    public override void Exit()
    {
    }
}