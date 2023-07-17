using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem Instance;
    
    void Start()
    {
         if (Instance == null) {
            EventSystem.Instance = this;
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
