using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Can : MonoBehaviour
    {
        private GameplayScore gameplayScore;

        [Inject]
        private void Construct(GameplayScore gameplayScore)
        {
            this.gameplayScore = gameplayScore;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var playableItem = other.GetComponent<PlayableItem>();
            if (playableItem != null) 
                gameplayScore.Value += playableItem.IsGoodItem ? 1 : -1;
        }
    }
}