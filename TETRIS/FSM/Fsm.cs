namespace MyApp.FSM;

public abstract class Fsm(SceneManager fsm)
{
    public abstract void Enter();

    public abstract void Update(ConsoleKeyInfo? keyInfo);
    
    public abstract void Exit();
} 