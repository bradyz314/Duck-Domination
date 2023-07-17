using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterInfo : Info
{
    public new void ShowInfoScreen() {
        base.UpdateInfo(GameManager.Instance.characters[GameManager.Instance.index].GetComponent<Entity>().data);
        base.ShowInfoScreen();
    }
}
