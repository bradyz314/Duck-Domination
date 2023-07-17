using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrades : MonoBehaviour
{
    UpgradeButton selectedUpgrade;
    [SerializeField] CharacterInfo characterInfo;
    [SerializeField] GameObject confirmScreen;
    TMP_Text skillDescription;
    TMP_Text cost;
    GameObject upgradeButton;

    void Awake() {
        skillDescription = confirmScreen.transform.Find("UpgradeDescription").GetComponent<TMP_Text>();
        cost = confirmScreen.transform.Find("Cost").GetComponent<TMP_Text>();
        upgradeButton = confirmScreen.transform.Find("UpgradeButton").gameObject;
    }

    void OnEnable() {
        confirmScreen.SetActive(false);
    }
    
    public void SetSelected(UpgradeButton selected) {
        this.selectedUpgrade = selected;
        ShowConfirmScreen();
    }

    public void OnUpgrade() {
        selectedUpgrade.upgrade.OnUpgrade();
        UpdateConfirmScreen();
    }

    void UpdateConfirmScreen() {
        Upgrade u = selectedUpgrade.upgrade;
        skillDescription.text = u.upgradeDescription;
        if (selectedUpgrade.upgrade.CanStillBeUpgraded()) {
            cost.text = "Cost: " + u.cost;
            EnableUpgradeButton(GameManager.Instance.playerCoins >= u.cost);
            characterInfo.UpdateInfo(u.entity.data);
        } else {
            cost.text = "Max Level Reached";
            EnableUpgradeButton(false);
        }
        selectedUpgrade.UpdateText();
    }

    void EnableUpgradeButton(bool enabled) {
        HoverButton hoverButton = upgradeButton.GetComponent<HoverButton>();
        hoverButton.OnEnable();
        if (enabled) {
            upgradeButton.GetComponent<Button>().interactable = true;
            hoverButton.enabled = true;
        } else {
            upgradeButton.GetComponent<Button>().interactable = false;
            hoverButton.enabled = false;
        }
    }

    void ShowConfirmScreen() {
        UpdateConfirmScreen();
        confirmScreen.SetActive(true);
    }
}
