using _Game.Scripts.Data;

class EnteringToMainMenuState : IState
{
    private SceneLoader sceneLoader;
    private GameStateMachine gameStateMachine;

    public EnteringToMainMenuState(SceneLoader sceneLoader, GameStateMachine gameStateMachine)
    {
        this.sceneLoader = sceneLoader;
        this.gameStateMachine = gameStateMachine;
    }

    public void Enter()
    {
        sceneLoader.LoadSceneWith(Constants.MainMenuSceneName);
        gameStateMachine.Enter<MainMenuState>();
    }

    public void Exit()
    {
        
    }
}