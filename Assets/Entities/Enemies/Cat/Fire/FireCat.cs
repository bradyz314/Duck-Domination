using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCat : Entity
{
    protected new void Awake() {
        base.Awake();
        base.Skills = new SkillState[1];
        base.Skills[0] = new ContactAttackState(this, StateMachine, data, "Attack", 0.733f, 2f, 1, "AttackPoint");
    }
}
