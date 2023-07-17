using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampireduck : Character
{
    float baseAttack;
    float baseSpeed;

    protected new void Awake() {
        base.Awake();
        base.Skills[0] = new ContactAttackState(this, StateMachine, data, "Attack", 0.433f, 1f, 1f, "AttackPoint");
        base.Skills[1] = new ContactAttackState(this, StateMachine, data, "Skill", 0.517f, 8f, 0f, "SkillPoint");
        baseAttack = base.data.attackStat;
        baseSpeed = base.data.speed;
    }

    public void UseHealth() {
        base.ApplyDamage(base.currHealth * 0.10f);
    }

    public void Heal() {
        if (base.currHealth < base.data.maxHealth * 0.30f) base.ApplyDamage(-25);
    }

    public void SetSkillDamage() {
        ((ContactAttackState)(base.Skills[1])).attackDamage.damage = GetMissingHealth() * 0.4f;
    }

    protected new void Update() {
        float missingHP = GetMissingHealth();
        if (((ActivatePassiveUpgrade)(base.upgrades[2])).isActivated) base.data.attackStat = baseAttack + (missingHP * 0.1f);
        if (((ActivatePassiveUpgrade)(base.upgrades[3])).isActivated) base.data.speed = baseSpeed + (missingHP  * 0.002f);
        base.Update();
    }

    float GetMissingHealth() {
        return (base.data.maxHealth - base.currHealth);
    }
}
