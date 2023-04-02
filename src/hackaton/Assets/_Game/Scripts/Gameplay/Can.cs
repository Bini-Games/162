using UnityEngine;

namespace Gameplay
{
    public class Can : MonoBehaviour
    {
        private GameplayScore gameplayScore;
        
        private void OnTriggerEnter(Collider other)
        {
            var playableItem = other.GetComponent<PlayableItem>();
            if (playableItem != null) 
                gameplayScore.Value += playableItem.IsGoodItem ? 1 : -1;
        }
    }
}