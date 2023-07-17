using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCat : Entity
{
    public GameObject poisonBombPrefab;

    protected new void Awake() {
        base.Awake();
        base.Skills = new SkillState[1];
        base.Skills[0] = new ProjectileAttackState(this, StateMachine, data, "Attack", 0.267f, 3f, poisonBombPrefab, 0f, 3, 120f, "AttackPoint");
    }
}
