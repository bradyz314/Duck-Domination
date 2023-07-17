using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorcererDog : Entity
{
    [SerializeField] protected GameObject projectilePrefab;
    protected new void Awake() {
        base.Awake();
        base.Skills = new SkillState[2];
        base.Skills[0] = new ProjectileAttackState(this, StateMachine, data, "Attack", 0.433f, 2f, projectilePrefab, 1f, 1, 0, "AttackPoint");
        base.Skills[1] = new ProjectileAttackState(this, StateMachine, data, "Attack", 0.433f, 8f, projectilePrefab, 1f, 8, 360f, "AttackPoint");
    }
}
