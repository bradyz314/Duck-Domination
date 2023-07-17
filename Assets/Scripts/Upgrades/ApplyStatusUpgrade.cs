using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyStatusUpgrade : Upgrade
{
    public string transformName;
    public bool isBuff;
    public StatusData status;

    public override void OnUpgrade() {
        base.OnUpgrade();
        DamageOnContact skillDamageOnContact = GameManager.Instance.characters[GameManager.Instance.index].transform.Find(transformName).GetComponent<DamageOnContact>();
        if (isBuff) {
            skillDamageOnContact.selfBuffData = status;
        } else {
            skillDamageOnContact.debuffData = status;
        }
    }
}
