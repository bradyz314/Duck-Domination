using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldStatusFactory : StatusFactory
{
    public float shieldHealth;
    public Sprite shieldSprite;
    public float duration;

    public override Status GetStatus(Entity target) {
        return new ShieldStatus {target = target, effectIcon = effectIcon, duration = duration, shieldHealth = shieldHealth, shieldSprite = shieldSprite};
    }

    public void SetValues(float shieldHealth, float duration) {
        this.shieldHealth = shieldHealth;
        this.duration = duration;
    }
}

public class ShieldStatus : Status {
    public float shieldHealth;
    public Sprite shieldSprite;
    public float duration;
    GameObject shieldEffect;
    float removalTime;

    public override void Apply() {
        base.Apply();
        target.data.currShieldHealth = shieldHealth;
        CreateShieldEffect();
        target.StartCoroutine(Unapplication());
    }

    void CreateShieldEffect() {
        shieldEffect = new GameObject();
        SpriteRenderer renderer = shieldEffect.AddComponent<SpriteRenderer>();
        renderer.sprite = shieldSprite;
        renderer.sortingLayerName = "Effects";
        shieldEffect.transform.SetParent(target.transform);
        shieldEffect.transform.localScale = new Vector3(1, 1, 1);
        shieldEffect.transform.localPosition = new Vector3(0, 0, 0);
        shieldEffect.SetActive(true);
    }

    IEnumerator Unapplication() {
        removalTime = Time.time + duration;
        yield return new WaitUntil(ShieldDestroyed);
        RemoveShield();
    }

    bool ShieldDestroyed() => (Time.time > removalTime || target.data.currShieldHealth == 0);

    void RemoveShield() {
        target.data.currShieldHealth = 0;
        GameObject.Destroy(shieldEffect);
        RemoveIconFromTargetStatusBar();
    }
}
