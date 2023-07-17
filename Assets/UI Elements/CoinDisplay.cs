using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text display;
    // Start is called before the first frame update
    void Update()
    {
        display.text = "" + GameManager.Instance.playerCoins;
    }
}
