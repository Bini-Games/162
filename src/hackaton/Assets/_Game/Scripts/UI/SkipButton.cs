using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.UI
{
    public class SkipButton : UIButton
    {
        public CanvasGroup CanvasGroup;
        
        private GameStateMachine gameStateMachine;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine) => 
            this.gameStateMachine = gameStateMachine;

        protected override void OnClick() => 
            gameStateMachine.Enter<EnteringToMainMenuState>();

        private void Start()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(CanvasGroup.DOFade(0, 3));
            sequence.Append(CanvasGroup.DOFade(1, 3));
            sequence.SetLoops(30);
        }
    }
}