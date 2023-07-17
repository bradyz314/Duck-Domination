using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBoss : Entity
{
    public GameObject[] availableSummons;
    public Bounds summonBounds;

    protected new void Awake() {
        base.Awake();
        base.Skills = new SkillState[3];
        base.Skills[0] = new ContactAttackState(this, StateMachine, data, "Attack", 0.267f, 3f, 1f, "AttackPoint");
        base.Skills[1] = new DashState(this, StateMachine, data, "Dash", 0.25f, 10f, 30f, 0.25f);
        summonBounds.center = gameObject.transform.position;
        base.Skills[2] = new SummonState(this, StateMachine, data, "Summon", 0.683f, 25f, availableSummons, summonBounds, 3); 
    }
}
