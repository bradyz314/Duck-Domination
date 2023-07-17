using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCat : Entity
{
    protected new void Awake() {
        base.Awake();
        base.Skills = new SkillState[1];
        base.Skills[0] = new DashState(this, StateMachine, data, "Attack", 0.25f, 3f, 45f, 1f);
    }
}
