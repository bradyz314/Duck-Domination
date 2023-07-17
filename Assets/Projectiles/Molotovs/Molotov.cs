using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov : MonoBehaviour
{
    public float duration;
    public float ticksPerSecond;
    Collider2D molotovCollider;

    void Awake() {
        molotovCollider = GetComponent<Collider2D>();
        StartCoroutine("ApplyMolotov");
    }

    IEnumerator ApplyMolotov() {
        float startTime = Time.time;
        double numOfTicks = duration * ticksPerSecond;
        double actualDuration = duration + numOfTicks * 0.01;
        while (Time.time - startTime <= actualDuration) {
            yield return new WaitForSeconds(1 / ticksPerSecond);
            molotovCollider.enabled = true;
            yield return new WaitForSeconds(0.01f);
            molotovCollider.enabled = false;
        }
        Destroy(this.gameObject);
    }
}
