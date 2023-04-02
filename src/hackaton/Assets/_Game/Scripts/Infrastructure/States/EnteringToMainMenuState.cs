using System.Threading.Tasks;
using _Game.Scripts.Data;

class EnteringToMainMenuState : IState
{
    private SceneLoader sceneLoader;
    private GameStateMachine gameStateMachine;
    
    public void Enter()
    {
        sceneLoader.LoadSceneWith(Constants.MainMenuSceneName);
        gameStateMachine.Enter<MainMenuState>();
    }

    public void Exit()
    {
        
    }
}