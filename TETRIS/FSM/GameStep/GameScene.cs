namespace MyApp.FSM;

public class GameScene(GameStepFSM fsm) : GameStep(fsm)
{
    public override void Enter()
    {
        Console.Clear();
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