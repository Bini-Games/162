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
            UpdateSaturation(-3);
            gameplayScore.OnValueChanged += UpdateSaturation;
        }

        private void UpdateSaturation(int value)
        {
            var score = (float) (gameplayScore.Value - 5) * 20;
            if (score > 20) 
                score = 20;
            
            postProcessProfile.GetSetting<ColorGrading>().saturation.value = score;
        }
    }
}