using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : Entity
{
    public GameObject yarnPrefab;
    public GameObject poisonPrefab;

    protected new void Awake() {
        base.Awake();
        base.Skills = new SkillState[3];
        base.Skills[0] = new ContactAttackState(this, StateMachine, data, "Slash", 0.733f, 3f, 1, "AttackPoint");
        base.Skills[1] = new ProjectileAttackState(this, StateMachine, data, "Idle", 1f, 5f, yarnPrefab, 0.5f, 10, 360f, "ProjectilePoint");
        base.Skills[2] = new ProjectileAttackState(this, StateMachine, data, "Idle", 1f, 10f, poisonPrefab, 0f, 5, 360f, "ProjectilePoint");
    }
}
