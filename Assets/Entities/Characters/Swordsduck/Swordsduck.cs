using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsduck : Character
{
    protected new void Awake() {
        base.Awake();
        base.Skills[0] = new ContactAttackState(this, StateMachine, data, "Attack", 0.517f, 1f, 1f, "AttackPoint");
        base.Skills[1] = new DashState(this, StateMachine, data, "Skill", 0.25f, 3f, 20f, 0.5f);
    }
}
