using System;
using Cysharp.Threading.Tasks;
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
        
        private async UniTask DestroyWithTimeout(GameObject item)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(2));
            if (!(item == null))
                Destroy(item);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var playableItem = other.GetComponent<PlayableItem>();
            if (playableItem == null || playableItem.Used)
                return;
            
            gameplayScore.Value += playableItem.IsGoodItem ? 1 : -1;
            playableItem.Used = true;
            DestroyWithTimeout(playableItem.gameObject).Forget();
        }
    }
}