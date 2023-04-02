using DG.Tweening;
using UnityEngine;

namespace Gameplay
{
    public class PlayableItem : MonoBehaviour
    {
        public bool IsGoodItem;

        private GameplayData data;
        private Can can;
        
        public void StartMoveToCan()
        {
            transform.DOJump(can.transform.position, 1, 1, data.CurrentSettings.MediumDuration);
        }
    }
}