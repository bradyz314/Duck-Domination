using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSkillState : SkillState
{
    public SkillState[] skills;
    string parameter;
    int index;
    int skillToSwitchTo;

    public SwitchSkillState(Entity entity, EntityStateMachine stateMachine, EntityData data, string animParameterName, float skillDuration, float skillCooldown, SkillState[] skills, int index, string parameter) : base(entity, stateMachine, data, animParameterName, skillDuration, skillCooldown) {
        this.skills = skills;
        this.index = index;
        this.parameter = parameter;
    }

    public override void Exit() {
        skillToSwitchTo++;
        if (skillToSwitchTo >= skills.Length) skillToSwitchTo = 0;
        entity.Skills[index] = skills[skillToSwitchTo];
        entity.Anim.SetBool(parameter, !entity.Anim.GetBool(parameter));
        base.Exit();
    }
}
