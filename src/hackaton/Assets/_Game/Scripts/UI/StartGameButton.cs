using _Game.Scripts.Data;
using Gameplay;
using Zenject;

namespace _Game.Scripts.UI
{
    public class StartGameButton : UIButton
    {
        private SceneLoader sceneLoader;
        
        private GameplayData gameplayData;

        public Difficulty Difficulty;

        [Inject]
        private void Construct(SceneLoader sceneLoader, GameplayData gameplayData)
        {
            this.sceneLoader = sceneLoader;
            this.gameplayData = gameplayData;
        }

        protected override void OnClick()
        {
            gameplayData.CurrentLevel = (int) Difficulty;
            sceneLoader.LoadSceneWith(Constants.GamePlayScene);
        }
    }
}