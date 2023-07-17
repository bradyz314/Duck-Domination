using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region State Machine Variables
    public EntityStateMachine StateMachine {get; private set;} 
    public EntityState IdleState {get; private set;}
    public EntityState MoveState {get; private set;}
    public DeathState DeadState {get; private set;}
    public SkillState[] Skills {get; protected set;}
    #endregion
    #region Entity Data
    public EntityData data;
    public float currHealth;
    public bool canMove;
    public bool facingRight = true;
    public Vector2 attackDirection; // For ranged attacks
    #endregion
    #region Entity UI
    [SerializeField] GameObject entityUIPrefab;
    public GameObject entityUI;
    public Transform statusBar;
    HealthBar healthBar;
    #endregion
    #region Components
    public Animator Anim {get; private set;}
    public Rigidbody2D Rb {get; private set;}
    #endregion
    #region Unity Callback Functions
    public void Awake() {
        StateMachine = new EntityStateMachine();    // Create a new FSM for this entity
        IdleState = new IdleState(this, StateMachine, data, "Idle");
        MoveState = new MoveState(this, StateMachine, data, "Moving");
        DeadState = new DeathState(this, StateMachine, data, "Dead");
        currHealth = data.maxHealth;
        CreateEntityUI();
        canMove = true;
    }

    public void Start() {
        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(IdleState);
    }

    protected void Update() { 
        StateMachine.CurrentState.LogicUpdate();
    }
    #endregion
    
    #region Health & Status Effects
    public void ApplyDamage(float damage) {
        float shield = data.currShieldHealth;
        if (shield > 0 && shield >= damage) {
            data.currShieldHealth -= damage;
            return;
        } else {
            damage -= shield;
            data.currShieldHealth = 0;
            currHealth -= damage;
            if (currHealth <= 0) {
                StateMachine.ChangeState(DeadState);
            } else if (currHealth >= data.maxHealth) {
                currHealth = data.maxHealth;
            } 
        }
        healthBar.UpdateHealthBar(data.maxHealth, currHealth);
    }
    #endregion
    #region Other Functions
    public void CheckIfShouldFlip(float x) {
        if ((x < 0 && facingRight) || (x > 0 && !facingRight)) {
            FlipEntity();
        } 
    }

    void FlipEntity() {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void LockMovement() {
        canMove = false;
        Rb.velocity = Vector2.zero;
    }

    public void UnlockMovement() {
        canMove = true;
    }

    void CreateEntityUI() {
        entityUI = Instantiate(entityUIPrefab);
        healthBar = entityUI.transform.Find("HealthBar").Find("FilledBar").GetComponent<HealthBar>();
        statusBar = entityUI.transform.Find("Status");
        Transform uiTransform = entityUI.GetComponent<Transform>();
        uiTransform.SetParent(transform);
        uiTransform.localPosition = new Vector3(0, data.healthBarYOffset, 0);
    }
    #endregion
}
