using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeserkerDog : Entity
{
    protected new void Awake() {
        base.Awake();
        base.Skills = new SkillState[2];
        base.Skills[0] = new ContactAttackState(this, StateMachine, data, "Attack", 0.6f, 2f, 0.8f, "AttackPoint");
        base.Skills[1] = new ContactAttackState(this, StateMachine, data, "Skill", 0.6f, 15f, 0.5f, "SkillPoint");
    }
}
