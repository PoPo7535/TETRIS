namespace MyApp.FSM;

public class GameStepFSM
{
    private GameStep curGameStep;
    private GameStep mainTitle;
    private GameStep gameScene;
    public GameStepFSM()
    {
        mainTitle = new MainTitle(this);
        gameScene = new GameScene(this);
        
        curGameStep = mainTitle;
        curGameStep.Enter();
    }
    
    public void Update(ConsoleKeyInfo? keyInfo)
    {
        curGameStep.Update(keyInfo);
    }

    public void ChangeStep(EGameStep gameStep)
    {
        curGameStep.Exit();
        var nextStep = gameStep switch
        {
            EGameStep.MainTitle => mainTitle,
            EGameStep.GameScene => gameScene,
            _ => mainTitle
        };
        curGameStep = nextStep;
        curGameStep.Enter();
    }

    public enum EGameStep
    {
        MainTitle,
        GameScene
    }
}