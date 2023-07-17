using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity
{
    public Upgrade[] upgrades;

    public new void Awake() {
        base.Awake();
        base.Skills = new SkillState[2];
    }
}
