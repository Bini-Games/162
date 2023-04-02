using _Game.Scripts.Data;
using Gameplay;
using Zenject;

namespace _Game.Scripts.UI
{
    class LevelDifficultyButton : UIButton
    {
        private GameplayData gameplayData;

        public Difficulty Difficulty;
        
        [Inject]
        private void Construct(GameplayData gameplayData) => 
            this.gameplayData = gameplayData;

        protected override void OnClick() => 
            gameplayData.CurrentLevel = (int) Difficulty;
    }
}