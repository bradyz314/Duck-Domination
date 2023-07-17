using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityState
{
    // State Fields
    protected Entity entity;    // Reference to the owner of the FSM
    protected EntityStateMachine stateMachine;  // Reference to the FSM
    protected EntityData data;  // The data of the entity
    protected float startTime;  // A float that keeps track of when the state was entered
    // Animator
    private string animParameterName; // A string representing the name of parameter for the animator

    // Constructor
    public EntityState(Entity entity, EntityStateMachine stateMachine, EntityData data, string animParameterName) {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.data = data;
        this.animParameterName = animParameterName;
    }

    // Enter will be called upon entering this state
    public virtual void Enter() {
        startTime = Time.time;
        if (animParameterName != null) entity.Anim.SetBool(animParameterName, true);
    }

    // Exit will be called upon exiting this state
    public virtual void Exit() {
        if (animParameterName != null) entity.Anim.SetBool(animParameterName, false);
    }

    // LogicUpdate will be called every frame while in this state
    public virtual void LogicUpdate() {}
}
