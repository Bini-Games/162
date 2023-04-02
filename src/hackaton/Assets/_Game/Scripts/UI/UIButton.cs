using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game.Scripts.UI
{
    public abstract class UIButton : MonoBehaviour, IPointerClickHandler
    {
        protected abstract void OnClick();
        
        public void OnPointerClick(PointerEventData eventData) => 
            OnClick();
    }
}