using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.UI
{
    public class CardOverlaySwitcher : MonoBehaviour
    {
        public List<CardOverlay> Overlays;

        private CardOverlay currentSelected;
        
        private void Awake() => 
            Overlays.ForEach(o => o.OnSelected += ChangeOverlay);

        private void OnDestroy() => 
            Overlays.ForEach(o => o.OnSelected -= ChangeOverlay);

        private void ChangeOverlay(CardOverlay sender, bool selected)
        {
            if (selected) return;
            
            if (currentSelected)
            {
                currentSelected.IsSelected = false;
                currentSelected.OnSelectedIcon.gameObject.SetActive(false);
            }
                
            sender.OnSelectedIcon.gameObject.SetActive(true);
            currentSelected = sender;
        }
    }
}