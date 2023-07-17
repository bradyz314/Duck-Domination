using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTStatusFactory : StatusFactory
{
    public float damage;
    public float tickTime;
    public float duration;

    public override Status GetStatus(Entity target) {
        return new DOTStatus {target = target, effectIcon = effectIcon, damage = damage, tickTime = tickTime, duration = duration};
    }

    public void SetValues(float damage, float tickTime, float duration) {
        this.damage = damage;
        this.tickTime = tickTime;
        this.duration = duration;
    }
}   

public class DOTStatus : Status {
    public float damage;
    public float tickTime;
    public float duration;

    public override void Apply() {
        base.Apply();
        target.StartCoroutine(Unapplication());
    }

    IEnumerator Unapplication() {
        float startTime = Time.time;
        while (Time.time - startTime <= duration) {
            yield return new WaitForSeconds(tickTime);
            target.ApplyDamage(damage);
        }
        RemoveIconFromTargetStatusBar();
    }
}
