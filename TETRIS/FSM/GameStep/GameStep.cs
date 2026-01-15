namespace MyApp.FSM;

public abstract class GameStep(GameStepFSM fsm)
{
    public abstract void Enter();

    public abstract void Update(ConsoleKeyInfo? keyInfo);

    protected abstract void Render();

    public abstract void Exit();
} 