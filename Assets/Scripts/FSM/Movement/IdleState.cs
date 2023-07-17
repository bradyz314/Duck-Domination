using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MovementState
{
    public IdleState(Entity entity, EntityStateMachine stateMachine, EntityData data, string animParameterName) : base(entity, stateMachine, data, animParameterName) {

    }

    public override void LogicUpdate() {
        base.LogicUpdate();
        if (velocity != Vector2.zero) {
            stateMachine.ChangeState(entity.MoveState);
        }
    }
}
