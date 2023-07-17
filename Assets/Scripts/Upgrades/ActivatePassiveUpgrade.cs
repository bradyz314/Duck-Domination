using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePassiveUpgrade : Upgrade
{
    public bool isActivated;

    public override void OnUpgrade() {
        base.OnUpgrade();
        isActivated = true;
    }
}
