using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : EntityState
{
    protected Vector2 velocity;

    public MovementState(Entity entity, EntityStateMachine stateMachine, EntityData data, string animParameterName) : base(entity, stateMachine, data, animParameterName) {
        
    }
    public override void LogicUpdate() {
        base.LogicUpdate();
        velocity = entity.Rb.velocity;
    }
}