namespace MyApp.FSM;

public class SceneManager
{
    private Fsm _curScene;
    private readonly Fsm _titleScene;
    private readonly Fsm _gameScene;
    public SceneManager()
    {
        _titleScene = new TitleScene(this);
        _gameScene = new GameScene(this);
        
        _curScene = _titleScene;
        _curScene.Enter();
    }
    
    public void Update(ConsoleKeyInfo? keyInfo)
    {
        _curScene.Update(keyInfo);
    }

    public void ChangeStep(SceneStep gameStep)
    {
        _curScene.Exit();
        var nextStep = gameStep switch
        {
            SceneStep.MainTitle => _titleScene,
            SceneStep.GameScene => _gameScene,
            _ => _titleScene
        };
        _curScene = nextStep;
        _curScene.Enter();
    }


}