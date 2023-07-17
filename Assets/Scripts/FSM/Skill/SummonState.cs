using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonState : SkillState
{
    GameObject[] availableSummons;
    Bounds summonBounds;
    int numberOfSummons;

    public SummonState(Entity entity, EntityStateMachine stateMachine, EntityData data, string animParameterName, float skillDuration, float skillCooldown, GameObject[] availableSummons, Bounds summonBounds, int numberOfSummons) : base(entity, stateMachine, data, animParameterName, skillDuration, skillCooldown) {
        this.availableSummons = availableSummons;
        this.summonBounds = summonBounds;
        this.numberOfSummons = numberOfSummons;
    }

    public override void Exit() {
        Summon();
        base.Exit();
    }

    void Summon() {
        int randIndex = Random.Range(0, availableSummons.Length);
        for (int i = 0; i < numberOfSummons; i++) {
            float offsetX = Random.Range(-summonBounds.extents.x, summonBounds.extents.x);
            float offsetY = Random.Range(-summonBounds.extents.y, summonBounds.extents.y);
            GameObject newEntity = GameObject.Instantiate(availableSummons[randIndex]);
            newEntity.transform.position = summonBounds.center + new Vector3(offsetX, offsetY, 0);
        }
    }
}
