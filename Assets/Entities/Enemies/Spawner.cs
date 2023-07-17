using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    const int DESPAWN_RANGE = 35;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int numOfCoins;
    GameObject player;
    GameObject spawned;
    Entity spawnedEntityComp;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (player == null) player = other.gameObject;
        if (spawned == null) {
            spawned = GameObject.Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);;
            spawnedEntityComp = spawned.GetComponent<Entity>();
        }
    }

    void OutOfRange() {
        if (Vector3.Distance(player.transform.position, spawned.transform.position) > DESPAWN_RANGE) {
            GameObject.Destroy(spawned);
        } 
    }

    void Update() {
        if (spawned != null) {
            if (!spawnedEntityComp.enabled) {
                GameObject.Destroy(gameObject);
                LevelManager.Instance.EnemyDefeated(numOfCoins);
            }
            OutOfRange();
        }
    }
}
