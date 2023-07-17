using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : SkillState
{
    Collider2D dashCollider;
    DamageOnContact dashDamage;
    float dashSpeed;
    TrailRenderer dashTrail;
    
    float attackScaling;
    int originalLayer;

    public DashState(Entity entity, EntityStateMachine stateMachine, EntityData data, string animParameterName, float skillDuration, float skillCooldown, float dashSpeed, float attackScaling) : base(entity, stateMachine, data, animParameterName, skillDuration, skillCooldown) {
        Transform dashColliderObject = entity.transform.Find("DashCollider");
        dashCollider = dashColliderObject.GetComponent<Collider2D>();
        dashDamage = dashColliderObject.GetComponent<DamageOnContact>();
        dashDamage.attacker = entity;
        dashTrail = entity.transform.Find("DashTrail").GetComponent<TrailRenderer>();
        this.dashSpeed = dashSpeed;
        this.attackScaling = attackScaling;
        originalLayer = entity.gameObject.layer;
    }

    public override void Enter() {
        dashDamage.damage = entity.data.attackStat * attackScaling; // Update the damage of the dash 
        Vector2 dashVelocity = GetDashVelocity(); 
        base.Enter();
        entity.gameObject.layer = LayerMask.NameToLayer("Dashing"); // Update the player's layer so that it dashes through enemies
        dashCollider.enabled = true; // Enable the dash collider to deal damage to any enemies that the player dashed through
        dashTrail.emitting = true; // Emit the Trailrenderer for the dash effect
        entity.canMove = false; // Prevent player input from resetting the velocity
        entity.Rb.velocity = dashVelocity;
    }

    public override void Exit() {
        base.Exit();
        entity.gameObject.layer = originalLayer; // Reset the player's layer so that it collides with enemies
        dashCollider.enabled = false; // Disable the dash collider
        dashTrail.emitting = false; // Disable the Trailrenderer
        entity.canMove = true; // Allow for player input 
    }

    Vector2 GetDashVelocity() {
        Vector2 dashDirection = entity.Rb.velocity;
        if (dashDirection == Vector2.zero) {
            dashDirection = new Vector2((entity.facingRight) ? 1 : -1, 0);
        } else {
            dashDirection.Normalize();
        }
        return (dashDirection * dashSpeed);
    }
}
