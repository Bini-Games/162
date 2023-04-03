using _Game.Scripts.Data;

class MainMenuState : IState
{
    private SceneLoader sceneLoader;

    public MainMenuState(SceneLoader sceneLoader) => 
        this.sceneLoader = sceneLoader;

    public void Enter() => 
        sceneLoader.LoadSceneWith(Constants.MainMenuSceneName);

    public void Exit()
    {
        
    }
}