using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedStatusFactory : StatusFactory
{
    public float percentage;
    public float duration;

    public override Status GetStatus(Entity target) {
        return new SpeedStatus {target = target, effectIcon = effectIcon, speedToAdd = target.data.speed * percentage, duration = duration};
    }

    public void SetValues(float percentage, float duration) {
        this.percentage = percentage;
        this.duration = duration;
    }
}

public class SpeedStatus : Status {
    public float speedToAdd;
    public float duration;

    public override void Apply() {
        base.Apply();
        target.data.speed += speedToAdd;
        target.StartCoroutine(Unapplication());
    }

    IEnumerator Unapplication() {
        yield return new WaitForSeconds(duration);
        target.data.speed -= speedToAdd;
        RemoveIconFromTargetStatusBar();
    }
}
