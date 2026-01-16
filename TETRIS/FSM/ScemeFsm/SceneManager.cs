namespace MyApp.FSM;

public class SceneManager
{
    private Fsm _curFsm;
    private readonly Fsm _mainTitle;
    private readonly Fsm _game;
    public SceneManager()
    {
        _mainTitle = new Title(this);
        _game = new Game(this);
        
        _curFsm = _mainTitle;
        _curFsm.Enter();
    }
    
    public void Update(ConsoleKeyInfo? keyInfo)
    {
        _curFsm.Update(keyInfo);
    }

    public void ChangeStep(SceneStep gameStep)
    {
        _curFsm.Exit();
        var nextStep = gameStep switch
        {
            SceneStep.MainTitle => _mainTitle,
            SceneStep.GameScene => _game,
            _ => _mainTitle
        };
        _curFsm = nextStep;
        _curFsm.Enter();
    }


}