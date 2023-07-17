using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackStatusFactory : StatusFactory {
    public float percentage;
    public float duration;

    public override Status GetStatus(Entity target) {
        return new AttackStatus {target = target, effectIcon = effectIcon, attackToAdd = target.data.attackStat * percentage, duration = duration};
    }

    public void SetValues(float percentage, float duration) {
        this.percentage = percentage;
        this.duration = duration;
    }
}

public class AttackStatus : Status {
    public float attackToAdd;
    public float duration;

    public override void Apply() {
        base.Apply();
        target.data.attackStat += attackToAdd;
        target.StartCoroutine(Unapplication());
    }

    IEnumerator Unapplication() {
        yield return new WaitForSeconds(duration);
        target.data.attackStat -= attackToAdd;
        RemoveIconFromTargetStatusBar();
    }
}
