using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDog : Entity
{
    protected new void Awake() {
        base.Awake();
        base.Skills = new SkillState[1];
        base.Skills[0] = new ContactAttackState(this, StateMachine, data, "Attack", 0.6f, 1.25f, 1f, "AttackPoint");
    }
}
