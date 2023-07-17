using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatUpgrade : Upgrade
{
    public int healthIncrease;
    public int attackIncrease;
    public float speedIncrease;

    public override void OnUpgrade() {
        base.OnUpgrade();
        entity.data.maxHealth += healthIncrease;
        entity.data.attackStat += attackIncrease;
        entity.data.speed += speedIncrease;
    }
}
