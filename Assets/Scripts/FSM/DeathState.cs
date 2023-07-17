using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : EntityState
{
    public DeathState(Entity entity, EntityStateMachine stateMachine, EntityData data, string animParameterName) : base(entity, stateMachine, data, animParameterName) {
        
    }

    public override void Enter() {
        base.Enter();
        entity.GetComponent<Collider2D>().enabled = false;
        EnemyController enemyController = entity.GetComponent<EnemyController>();
        entity.transform.Find("MinimapIcon").gameObject.SetActive(false);
        if (enemyController) enemyController.enabled = false;
        entity.Rb.velocity = Vector2.zero;
        entity.entityUI.SetActive(false);
        entity.enabled = false;
    }
}
