using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    public float damage;
    public Entity attacker;
    public string targetTag;
    public StatusData debuffData;
    public StatusData selfBuffData;

    void OnTriggerEnter2D(Collider2D other) {
        // Check if a object of the target tag was hit. If so, call the corresponding hit method;
        if (other.CompareTag(targetTag)) {
            Entity hitTarget = other.GetComponent<Entity>();  
            if (hitTarget) {
                hitTarget.ApplyDamage(damage);
                if (debuffData != null) StatusManager.Instance.ApplyStatusEffect(debuffData, hitTarget);
                if (selfBuffData != null) StatusManager.Instance.ApplyStatusEffect(selfBuffData, attacker);
            }
        }
    }
}
