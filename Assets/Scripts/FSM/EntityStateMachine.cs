using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStateMachine
{
    public EntityState CurrentState {get; private set;} // Variable to store the current state of the FSM

    public void Initialize(EntityState start) {
        CurrentState = start;
        CurrentState.Enter();
    }

    public void ChangeState(EntityState newState) {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
