using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI Instance;

    [SerializeField] GameObject playerUIPrefab;

    [SerializeField] Sprite victoryImage;
    [SerializeField] Sprite defeatImage;
    GameObject resultImage;
    
    public SpriteRenderer playerSpriteRenderer;
    GameObject ui;
    Canvas uiCanvas;
    Transform attackIcon;
    Transform skillIcon;
    TMP_Text remainingEnemiesText;
    GameObject pauseMenu;

    void Start()
    {
        if (Instance == null) {
            CreateUI();
            PlayerUI.Instance = this;
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void CreateUI() {
        ui = GameObject.Instantiate(playerUIPrefab, this.transform);
        uiCanvas = ui.GetComponent<Canvas>();
        attackIcon = ui.transform.Find("AttackIcon"); 
        skillIcon = ui.transform.Find("SkillIcon");
        remainingEnemiesText = ui.transform.Find("RemainingEnemies").GetComponent<TMP_Text>();
        resultImage = ui.transform.Find("Result").gameObject;
        pauseMenu = ui.transform.Find("PauseMenu").gameObject;
        Component[] c = pauseMenu.transform.Find("PlayButton").gameObject.GetComponents(typeof(Component));
        pauseMenu.transform.Find("PlayButton").GetComponent<Button>().onClick.AddListener(ResumeGame);
        pauseMenu.transform.Find("ExitButton").GetComponent<Button>().onClick.AddListener(ExitFromPause);
        ui.SetActive(false);
    }

    public void OnLevelLoad(Entity e, int numOfEnemies) {
        uiCanvas.worldCamera = Camera.main;
        UpdateEnemiesRemaining(numOfEnemies);
        UpdateIcons(e);
        remainingEnemiesText.gameObject.SetActive(true);
        resultImage.SetActive(false);
        ui.SetActive(true);
    }

    public void Exit() {
        Time.timeScale = 1;
        ui.SetActive(false);
    }

    public void ExitFromPause() {
        pauseMenu.SetActive(false);
        Exit();
        LevelManager.Instance.Exit();
    }

    public void ShowResult(bool victory) {
        remainingEnemiesText.gameObject.SetActive(false);
        resultImage.GetComponent<Image>().sprite = victory ? victoryImage : defeatImage;
        resultImage.SetActive(true);
    }

    public void PauseGame() {
        Time.timeScale = 0;
        playerSpriteRenderer.enabled = false;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame() {
        Time.timeScale = 1;
        playerSpriteRenderer.enabled = true;
        pauseMenu.SetActive(false);
    }

    public void UpdateEnemiesRemaining(int n) {
        if (n == 0) {
            remainingEnemiesText.text = "All enemies defeated! Proceed to the boss room!";
        } else {
            string temp = (n > 1) ? "Enemies" : "Enemy";
            remainingEnemiesText.text = "" + n + " " + temp + " Remaining";
        }
    }

    void UpdateIcons(Entity e) {
        attackIcon.transform.Find("CanAttack").GetComponent<Image>().sprite = e.data.skillIcons[0];
        Transform attackCooldown = attackIcon.transform.Find("OnCooldown");
        attackCooldown.GetComponent<Image>().sprite = e.data.skillIcons[0];
        attackCooldown.GetComponent<Icon>().entity = e;
        skillIcon.transform.Find("CanSkill").GetComponent<Image>().sprite = e.data.skillIcons[1];
        Transform skillCooldown = skillIcon.transform.Find("OnCooldown");
        skillCooldown.GetComponent<Image>().sprite = e.data.skillIcons[1];
        skillCooldown.GetComponent<Icon>().entity = e;
    }
}
