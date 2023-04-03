using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class FinishGameAudio : MonoBehaviour
{
    private GameStateMachine gameStateMachine;

    public AudioSource AudioSource;

    [Inject]
    public void Construct(GameStateMachine stateMachine) =>
        gameStateMachine = stateMachine;

    private void Start() => 
        PlayAudio();

    private async UniTask PlayAudio()
    {
        AudioSource.Play();
        await UniTask.WaitWhile(() => AudioSource.isPlaying);
        gameStateMachine.Enter<MainMenuState>();
    }
}
