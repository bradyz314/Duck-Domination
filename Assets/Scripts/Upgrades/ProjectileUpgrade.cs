using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileUpgrade : Upgrade
{
    public StatusData data;
    public bool applyStatus;
    public int increaseInProjectiles;
    public int numOfProjectiles;
    
    public override void OnUpgrade() {
        base.OnUpgrade();
        if (increaseInProjectiles != 0) {
            numOfProjectiles++;
        }
        if (data != null) {
            applyStatus = true;
        }
    }
}
