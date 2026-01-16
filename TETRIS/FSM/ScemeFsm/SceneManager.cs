namespace MyApp.FSM;

public class SceneManager
{
    private SceneFsm _curSceneFsm;
    private readonly SceneFsm _mainTitle;
    private readonly SceneFsm _gameScene;
    public SceneManager()
    {
        _mainTitle = new TitleScene(this);
        _gameScene = new GameScene(this);
        
        _curSceneFsm = _mainTitle;
        _curSceneFsm.Enter();
    }
    
    public void Update(ConsoleKeyInfo? keyInfo)
    {
        _curSceneFsm.Update(keyInfo);
    }

    public void ChangeStep(SceneStep gameStep)
    {
        _curSceneFsm.Exit();
        var nextStep = gameStep switch
        {
            SceneStep.MainTitle => _mainTitle,
            SceneStep.GameScene => _gameScene,
            _ => _mainTitle
        };
        _curSceneFsm = nextStep;
        _curSceneFsm.Enter();
    }


}