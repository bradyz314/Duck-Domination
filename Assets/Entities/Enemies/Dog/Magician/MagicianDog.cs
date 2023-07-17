using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianDog : Entity
{
    [SerializeField] protected GameObject projectilePrefab;
    protected new void Awake() {
        base.Awake();
        base.Skills = new SkillState[1];
        base.Skills[0] = new ProjectileAttackState(this, StateMachine, data, "Attack", 0.433f, 2f, projectilePrefab, 1f, 1, 0f, "AttackPoint");
    }
}
