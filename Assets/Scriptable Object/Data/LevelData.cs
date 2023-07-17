using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Data/Level Data")]
public class LevelData : ScriptableObject
{
    public bool isLocked;
    public LevelData nextLevel;
    [SerializeField] public Sprite bossSprite;
    public int levelSceneIndex;

    public int numOfEnemies;
    public Vector3 playerSpawnPoint;

    public void UnlockNext() {
        if (nextLevel != null) nextLevel.isLocked = false;
    }
}
