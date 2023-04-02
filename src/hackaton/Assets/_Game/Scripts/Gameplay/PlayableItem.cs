using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayableItem : MonoBehaviour
    {
        public bool IsGoodItem;

        private GameplayData data;
        private Can can;

        [Inject]
        private void Construct(GameplayData data, Can can)
        {
            this.data = data;
            this.can = can;
        }
        
        public void StartMoveToCan()
        {
            //transform.DOJump(can.transform.position, 1, 1, data.CurrentSettings.MediumDuration);
        }
    }
}