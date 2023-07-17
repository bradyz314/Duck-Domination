using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDog : Entity
{
    protected new void Awake() {
        base.Awake();
        base.Skills = new SkillState[1];
        base.Skills[0] = new ContactAttackState(this, StateMachine, data, "Attack", 0.517f, 1f, 1f, "AttackPoint");
    }

    public void Explode() {
        base.StateMachine.ChangeState(base.DeadState);
    }
}
