using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Info : MonoBehaviour
{
    [SerializeField] GameObject screen;
    public GameObject[] infoScreens;
    protected int index = 0;
    #region Stats
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text attackText;
    [SerializeField] TMP_Text speedText;
    #endregion
    #region Abilities
    public GameObject[] abilityDescriptions;
    #endregion

    void Awake()
    {
        infoScreens[0].SetActive(true);
        for (int i = 1; i < infoScreens.Length; i++) {
            infoScreens[i].SetActive(false);
        }
    }

    public void NextScreen() {
        infoScreens[index].SetActive(false);
        index++; 
        if (index >= infoScreens.Length) index = 0;      
        infoScreens[index].SetActive(true);
    }

    public void PrevScreen() {
        infoScreens[index].SetActive(false);
        index--;
        if (index < 0) index = infoScreens.Length - 1;
        infoScreens[index].SetActive(true);
    }

    public void ShowInfoScreen() {
        infoScreens[index].SetActive(true);
        screen.SetActive(true);
    }

    public void HideInfoScreen() {
        infoScreens[index].SetActive(false);
        foreach (GameObject description in abilityDescriptions) {
            description.SetActive(false);
        }
        index = 0;
        screen.SetActive(false);
    }

    public virtual void UpdateInfo(EntityData data) {
        healthText.text = data.maxHealth.ToString();
        attackText.text = data.attackStat.ToString();
        speedText.text = data.speed.ToString();
        int length = data.skillIcons.Length;
        for (int i = 0; i < abilityDescriptions.Length; i++) {
            if (i >= length) break;
            abilityDescriptions[i].transform.Find("AbilityIcon").GetComponent<Image>().sprite = data.skillIcons[i];
            abilityDescriptions[i].transform.Find("Description").GetComponent<TMP_Text>().text = data.descriptions[i];
            abilityDescriptions[i].SetActive(true);
        }
    }
}
