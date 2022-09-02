using System.Collections;
using UnityEngine;

public class BallStateMachine
{
    internal IState currentState;

    internal void InitializeState(IState initialState)
    {
        currentState = initialState;
        currentState.Enter();
    }

    internal void ChangeState(IState state)
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }
}