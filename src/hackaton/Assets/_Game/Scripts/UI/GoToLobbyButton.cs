using Zenject;

namespace _Game.Scripts.UI
{
    public class GoToLobbyButton : UIButton
    {
        private GameStateMachine gameStateMachine;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine) => 
            this.gameStateMachine = gameStateMachine;

        protected override void OnClick() => 
            gameStateMachine.Enter<MainMenuState>();
    }
}