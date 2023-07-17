using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEStatusState : SkillState
{
    float range;
    LayerMask targetLayers;
    StatusData[] enemyStatuses;
    StatusData[] playerStatuses;

    public AOEStatusState(Entity entity, EntityStateMachine stateMachine, EntityData data, string animParameterName, float skillDuration, float skillCooldown, float range, StatusData[] enemyStatuses, StatusData[] playerStatuses, LayerMask targetLayers) : base(entity, stateMachine, data, animParameterName, skillDuration, skillCooldown) {
        this.range = range;
        this.enemyStatuses = enemyStatuses;
        this.playerStatuses = playerStatuses;
        this.targetLayers = targetLayers;
    }

    public override void Exit() {
        ApplyStatuses();
        base.Exit();
    }

    void ApplyStatuses() {
        Collider2D[] entities = Physics2D.OverlapCircleAll(entity.transform.position, range, targetLayers);
        foreach (Collider2D c in entities) {
            Entity e = c.GetComponent<Entity>();
            if (e) {
                if (c.CompareTag("Player") && playerStatuses.Length != 0) {
                    StatusManager.Instance.ApplyStatusEffect(playerStatuses[Random.Range(0, playerStatuses.Length)], e);
                } else if (c.CompareTag("Enemy") && enemyStatuses.Length != 0) {
                    StatusManager.Instance.ApplyStatusEffect(enemyStatuses[Random.Range(0, enemyStatuses.Length)], e);
                }
            }
        }
    }
}
