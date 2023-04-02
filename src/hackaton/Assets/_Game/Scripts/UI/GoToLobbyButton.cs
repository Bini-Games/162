namespace _Game.Scripts.UI
{
    public class GoToLobbyButton : UIButton
    {
        private GameStateMachine gameStateMachine;
        
        protected override void OnClick() => 
            gameStateMachine.Enter<EnteringToMainMenuState>();
    }
}