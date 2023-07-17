using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelection : MonoBehaviour
{
    public GameObject[] enemyButtons;
    public int index = 0;

    public void ShowButtons() {
        enemyButtons[index].SetActive(true);
    }
}
