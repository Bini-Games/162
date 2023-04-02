using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace Gameplay
{
    public class GameplayArbiter : IInitializable
    {
        private LevelBuilder levelBuilder;

        [Inject]
        public GameplayArbiter(LevelBuilder levelBuilder) => 
            this.levelBuilder = levelBuilder;

        public void Initialize() => 
            levelBuilder.OnObjectsFinished += (_, __) => FinishGame();

        private async void FinishGame()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(3));
            SceneManager.LoadScene("FinishGame");
        }
    }
}