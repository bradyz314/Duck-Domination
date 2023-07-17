using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
using UnityEngine.UI;
using Cinemachine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public LevelData currentLevelData;
    Entity player;
    GameObject bossRoomCollider;
    int numOfEnemies;
    bool levelFinished;
    int coins;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null) {
            LevelManager.Instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (GameManager.Instance.currentState == GameManager.GameState.PlayingLevel && scene.buildIndex == currentLevelData.levelSceneIndex) StartCoroutine("StartLevel");
    }
    void SetUpLevel() {
        coins = 0;
        levelFinished = false;
        numOfEnemies = currentLevelData.numOfEnemies;
        GameObject playerObject = GameObject.Instantiate(GameManager.Instance.activeCharacter, currentLevelData.playerSpawnPoint, Quaternion.identity);
        playerObject.SetActive(true);
        PlayerUI.Instance.playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer>();
        player = playerObject.GetComponent<Entity>();
        GameObject.Find("PlayerCamera").GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
        bossRoomCollider = GameObject.Find("BossRoomCollider");
        PlayerUI.Instance.OnLevelLoad(player, numOfEnemies);
    }

    IEnumerator StartLevel() {
        SetUpLevel();
        while (!levelFinished) {
            if (!player.enabled) {
                Defeat();
                break;
            }
            yield return null;
        }

        yield return new WaitForSeconds(3);
        EndLevel();
    }

    public void EnemyDefeated(int numOfCoins) {
        numOfEnemies--;
        coins += numOfCoins;
        UpdateEnemiesRemaining(numOfEnemies);
    }

    public void Exit() {
        StopCoroutine("StartLevel");
        coins /= 4;
        EndLevel();
    }

    void Defeat() {
        PlayerUI.Instance.ShowResult(false);
        levelFinished = true;
    }

    void EndLevel() {
        GameManager.Instance.UpdateGameState(GameManager.GameState.GameMenu);
        GameManager.Instance.playerCoins += coins;
        PlayerUI.Instance.Exit();
    }

    void UpdateEnemiesRemaining(int n) {
        if (n < 0) {
            levelFinished = true;
            currentLevelData.UnlockNext();
            PlayerUI.Instance.ShowResult(true);
        } else {
            PlayerUI.Instance.UpdateEnemiesRemaining(n);
            if (n == 0) bossRoomCollider.SetActive(false);
        }
    }

    

    
}
