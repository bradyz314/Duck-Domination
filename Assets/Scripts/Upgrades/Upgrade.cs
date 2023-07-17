using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public Entity entity;
    public Sprite upgradeIcon;
    public string upgradeDescription;
    public int cost;
    public int costIncreasePerUpgrade;
    public int numberOfUpgrades;
    public int maxNumberOfUpgrades;

    public virtual void OnUpgrade() {
        GameManager.Instance.playerCoins -= cost;
        cost += costIncreasePerUpgrade;
        numberOfUpgrades++;
    }

    public bool CanStillBeUpgraded() {
        return numberOfUpgrades < maxNumberOfUpgrades;
    }
}
