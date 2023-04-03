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
            gameStateMachine.RegisterState(stateFactory.Create<MainMenuState>());
            gameStateMachine.RegisterState(stateFactory.Create<GamePlayState>());
            gameStateMachine.RegisterState(stateFactory.Create<GamePlayEndState>());
            
            gameStateMachine.Enter<MainMenuState>();
        }
    }
}