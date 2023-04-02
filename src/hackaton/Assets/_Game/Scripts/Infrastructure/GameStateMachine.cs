using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine 
{
    private IState currentState;

    private Dictionary<Type, IState> stateTypeToInstanceMap = new();
    
    public void RegisterState(IState create) => 
        stateTypeToInstanceMap.Add(create.GetType(), create);

    public void Enter<T>() where T : IState
    {
        currentState?.Exit();
        var state = stateTypeToInstanceMap[typeof(T)];
        state.Enter();
        currentState = state;
    }

    public void Exit<T>() where T : IState => 
        stateTypeToInstanceMap[typeof(T)].Exit();
}
