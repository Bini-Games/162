using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine 
{
    private IState currentState;

    private Dictionary<Type, IState> stateTypeToInstanceMap = new();
    
    public void RegisterState(IState create)
    {
        stateTypeToInstanceMap.Add(create.GetType(), create);
        var state = stateTypeToInstanceMap[typeof(PrepareGameState)];
        state.Enter();
    }

    public void Enter<T>() where T : IState
    {
        
    }

    public void Exit<T>() where T : IState
    {
        
    }
}
