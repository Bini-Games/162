using DG.Tweening;
using UnityEngine.Rendering.PostProcessing;
using Zenject;

namespace Gameplay
{
    public class SaturationUpdater : IInitializable
    {
        private PostProcessProfile postProcessProfile;
        private GameplayScore gameplayScore;

        [Inject]
        public SaturationUpdater(PostProcessProfile postProcessProfile, GameplayScore gameplayScore)
        {
            this.postProcessProfile = postProcessProfile;
            this.gameplayScore = gameplayScore;
        }

        public void Initialize()
        {
            gameplayScore.OnValueChanged += UpdateSaturation;
            gameplayScore.Value = 0;
        }

        private void UpdateSaturation(int value)
        {
            var score = (float) (gameplayScore.Value - 2) * 20;
            if (score > 20) 
                score = 20;
            if (score < -99)
                score = -99;
            
            postProcessProfile.GetSetting<ColorGrading>().saturation.value = score;
        }
    }
}