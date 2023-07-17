using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportDog : Entity
{
    public StatusData[] enemyStatuses;
    public StatusData[] playerStatuses;
    public LayerMask targetLayers;

    protected new void Awake() {
        base.Awake();
        base.Skills = new SkillState[1];
        base.Skills[0] = new AOEStatusState(this, base.StateMachine, base.data, "Attack", 0.433f, 5f, 3.2f, enemyStatuses, playerStatuses, targetLayers);
    }
}
