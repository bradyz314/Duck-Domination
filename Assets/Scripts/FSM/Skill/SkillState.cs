using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillState : EntityState
{
    #region Skill Availability
    public float skillDuration; 
    public float skillCooldown;
    float nextAvailableTime;
    #endregion

    public SkillState(Entity entity, EntityStateMachine stateMachine, EntityData data, string animParameterName, float skillDuration, float skillCooldown) : base(entity, stateMachine, data, animParameterName) {
        this.skillDuration = skillDuration;
        this.skillCooldown = skillCooldown;
    }

    public override void Enter() {
        base.Enter();
        entity.LockMovement();
    }

    public override void LogicUpdate() {
        base.LogicUpdate();
        if (Time.time > startTime + skillDuration) {
            entity.StateMachine.ChangeState(entity.IdleState);
        }
    }

    public override void Exit() {
        base.Exit();
        entity.UnlockMovement();
        entity.Rb.velocity = Vector2.zero;
        nextAvailableTime = Time.time + skillCooldown;
    }
    
    public float CheckIfSkillCanBeUsed() {
        return Time.time - nextAvailableTime;
    }
}
