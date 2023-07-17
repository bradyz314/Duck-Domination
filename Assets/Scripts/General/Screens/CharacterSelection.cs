using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelection : MonoBehaviour
{
    public EntityData[] characterData;
    #region Selection Screen
    [SerializeField] Image selectedCharacterImage;
    #endregion

    void Awake() {
        characterData = new EntityData[GameManager.Instance.characters.Length];
        for (int i = 0; i < characterData.Length; i++) {
            characterData[i] = GameManager.Instance.characters[i].GetComponent<Entity>().data;   
        }
        UpdateSelection();
    }

    public void NextCharacter() {
        int index = GameManager.Instance.index;
        index++; 
        if (index >= characterData.Length) index = 0;   
        GameManager.Instance.index = index;
        UpdateSelection();
    }

    public void PrevCharacter() {
        int index = GameManager.Instance.index;
        index--;
        GameManager.Instance.index--;
        if (index < 0) index = characterData.Length - 1;
        GameManager.Instance.index = index;
        UpdateSelection();
    }

    public void SetActiveCharacter() {
        GameManager.Instance.activeCharacter = GameManager.Instance.characters[GameManager.Instance.index];
    }

    void UpdateSelection() {
        EntityData selectedCharacterData = characterData[GameManager.Instance.index];
        selectedCharacterImage.sprite = selectedCharacterData.entityImage;
    }
}
