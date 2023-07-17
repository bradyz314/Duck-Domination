using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactAttackState : SkillState
{
    public DamageOnContact attackDamage;
    float attackScaling;

    public ContactAttackState(Entity entity, EntityStateMachine stateMachine, EntityData data, string animParameterName, float skillDuration, float skillCooldown, float attackScaling, string transformName) : base(entity, stateMachine, data, animParameterName, skillDuration, skillCooldown) {
        attackDamage = entity.transform.Find(transformName).GetComponent<DamageOnContact>();
        attackDamage.attacker = entity;
        this.attackScaling = attackScaling;
    }

    public override void Enter() {
        attackDamage.damage = entity.data.attackStat * attackScaling;
        base.Enter();
    }
}
