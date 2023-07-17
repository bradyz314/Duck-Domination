using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : HoverButton
{   
    public Upgrade upgrade;
    public Image upgradeImage;
    public Upgrades upgrades;
    public TMP_Text upgradeText;
    public int index;

    new void OnEnable() {
        base.OnEnable();
        upgrade = GameManager.Instance.characters[GameManager.Instance.index].GetComponent<Character>().upgrades[index];
        upgradeImage.sprite = upgrade.upgradeIcon;
        UpdateText();
    }

    public void UpdateText() {
        upgradeText.text = "" + upgrade.numberOfUpgrades + "/" + upgrade.maxNumberOfUpgrades;
    }

    public new void OnClick() {
        upgrades.SetSelected(this);
    }
}
