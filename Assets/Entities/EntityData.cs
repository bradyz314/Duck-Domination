using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityData : MonoBehaviour
{
    [Header("Move State")]
    public ContactFilter2D movementFilter; // Specify which collisions should impact the Player when moving
    public float speed; // Variable to specify how fast the player should move
    [Header("Images")]
    public Sprite entityImage;
    public Sprite[] skillIcons;
    public string[] descriptions;
    [Header("Stats")]
    public float attackStat; // Player's attack stat
    public float maxHealth; // Player's maximum health
    [Header("Shield")]
    public float currShieldHealth;
    [Header("UI")]
    public float healthBarYOffset;
}
