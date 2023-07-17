using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum GameState {
        MainMenu, HowToPlay, GameMenu, CharacterSelection, EnemyInfo, PlayingLevel
    }
    public GameState currentState;
    #region Character Selection
    public GameObject[] characters;
    public int index;
    #endregion
    public GameObject activeCharacter; 
    public int playerCoins;
    
    void Start()
    {
        if (Instance == null) {
            GameManager.Instance = this;
            playerCoins = 100;
            InitializeCharacters();
            UpdateGameState(GameState.MainMenu);
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void UpdateGameState(GameState newState) {
        currentState = newState;
        switch (currentState) {
            case GameState.MainMenu:
                LoadScene(0);
                break;
            case GameState.HowToPlay:
                LoadScene(1);
                break;
            case GameState.GameMenu:
                LoadScene(2);
                break;
            case GameState.CharacterSelection:
                index = 0;
                LoadScene(3);
                break;
            case GameState.EnemyInfo:
                LoadScene(4);
                break;
        }
    }

    void InitializeCharacters() {
        for (int i = 0; i < characters.Length; i++) {
            characters[i] = GameObject.Instantiate(characters[i], gameObject.transform);
            Character c = characters[i].GetComponent<Character>();
            GameObject.Destroy(c.entityUI);
            characters[i].SetActive(false);
        }
    }

    void LoadScene(int buildIndex) {
         if (SceneManager.GetActiveScene().buildIndex != buildIndex) SceneManager.LoadScene(buildIndex);  
    }

}
