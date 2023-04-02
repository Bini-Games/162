using System.Threading.Tasks;
using _Game.Scripts.Data;

class EnteringToMainMenuState : IState
{
    private SceneLoader sceneLoader;
    private GameStateMachine gameStateMachine;
    
    public void Enter()
    {
        sceneLoader.LoadAsyncSceneBy(Constants.MainMenuSceneName);
        gameStateMachine.Enter<MainMenuState>();
    }

    public void Exit()
    {
        
    }
}