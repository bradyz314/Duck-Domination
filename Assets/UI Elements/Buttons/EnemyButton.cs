using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyButton : HoverButton
{
    [SerializeField] EntityData data;
    [SerializeField] Info enemyInfo;
    [SerializeField] Image enemyImage;
    
    void Awake() {
        enemyImage.sprite = data.entityImage;
    }

    public new void OnClick() {
        enemyInfo.UpdateInfo(data);
        enemyInfo.ShowInfoScreen();
    }
}
