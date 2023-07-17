using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Level : MonoBehaviour
{
    [SerializeField] Image levelImage;
    [SerializeField] Sprite lockImage;
    [SerializeField] TMP_Text errorMessage;
    [SerializeField] Color initialMessageColor;
    [SerializeField] LevelData data;

    void Awake() {
        if (data.isLocked) {
            levelImage.sprite = lockImage;
        } else {
            levelImage.sprite = data.bossSprite;
        }
    }

    public void LoadLevel() {
        LevelManager.Instance.currentLevelData = data;
        if (GameManager.Instance.activeCharacter == null) {
            DisplayErrorMessage("Select a character first!");
        } else { 
            if (!data.isLocked) {
                SceneManager.LoadScene(data.levelSceneIndex);
                GameManager.Instance.UpdateGameState(GameManager.GameState.PlayingLevel);
            } else {
                DisplayErrorMessage("Level Locked!");
            }
        }
    }

    void DisplayErrorMessage(string msg) {
        if (errorMessage.gameObject.activeSelf) {
            StopCoroutine("FadeMessage");
        }
        errorMessage.text = msg;
        StartCoroutine("FadeMessage");
    }

    IEnumerator FadeMessage() {
        Color messageColor = initialMessageColor;
        errorMessage.color = messageColor;
        errorMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        while (messageColor.a > 0) {
            messageColor.a -= 0.01f;
            errorMessage.color = messageColor;
            yield return null;
        }
        errorMessage.gameObject.SetActive(false);
    }
}
