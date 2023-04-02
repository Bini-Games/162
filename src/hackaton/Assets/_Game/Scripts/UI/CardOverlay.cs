using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game.Scripts.UI
{
    public class CardOverlay : MonoBehaviour, IPointerClickHandler
    {
        public event Action<CardOverlay,bool> OnSelected;

        public GameObject OnSelectedIcon;
        
        public bool IsSelected { get; set; }
        
        public void OnPointerClick(PointerEventData eventData) => 
            OnSelected?.Invoke(this, IsSelected);
    }
}