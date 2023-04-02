using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace Gameplay
{
    public class GameplayArbiter : IInitializable
    {
        private LevelBuilder levelBuilder;
        private GameplayScore score;

        [Inject]
        public GameplayArbiter(LevelBuilder levelBuilder, GameplayScore score)
        {
            this.levelBuilder = levelBuilder;
            this.score = score;
        }

        public void Initialize() => 
            levelBuilder.OnObjectsFinished += (_, __) => FinishGame();

        private async void FinishGame()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(2));
            SceneManager.LoadScene(score.Value > 0 ? "FinishGameGood" : "FinishGameBad");
        }
    }
}