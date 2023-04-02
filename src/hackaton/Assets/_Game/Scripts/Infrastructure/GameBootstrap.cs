using _Game.Scripts.Factories;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Infrastructure
{
    public class GameBootstrap : MonoBehaviour
    {
        [Inject]
        private void Construct(GameStateMachine gameStateMachine, StateFactory stateFactory)
        {
            gameStateMachine.RegisterState(stateFactory.Create<EnteringToMainMenuState>());
            gameStateMachine.RegisterState(stateFactory.Create<MainMenuState>());
            gameStateMachine.RegisterState(stateFactory.Create<PrepareGameState>());
            gameStateMachine.RegisterState(stateFactory.Create<GamePlayState>());
            gameStateMachine.RegisterState(stateFactory.Create<GamePlayEndState>());
            gameStateMachine.RegisterState(stateFactory.Create<ReloadGamePlayState>());
            
            gameStateMachine.Enter<EnteringToMainMenuState>();
        }
    }
}