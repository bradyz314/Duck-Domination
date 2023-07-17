using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Data/Status Data")]
public class StatusData : ScriptableObject
{
    public StatusManager.StatusType type;
    public float duration;
    public float percentage;
    public float damage;
    public float tickTime;
    public float shieldHealth;
}
