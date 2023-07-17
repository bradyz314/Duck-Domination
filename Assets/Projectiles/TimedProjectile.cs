using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedProjectile : Projectile
{
    public float duration;
    public GameObject molotov;

    protected new void Awake() {
        base.Awake();
        StartCoroutine("DestroyProjectile");
    }

    IEnumerator DestroyProjectile() {
        yield return new WaitForSeconds(duration);
        Destroy();
    }

    void OnTriggerEnter2D(Collider2D other) {
        Destroy();
    }

    public new void Destroy() {
        if (molotov != null) GameObject.Instantiate(molotov, this.gameObject.transform.position, Quaternion.identity);
        base.Destroy();
    }
}
