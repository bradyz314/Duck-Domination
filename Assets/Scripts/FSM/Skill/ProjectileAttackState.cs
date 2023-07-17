using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttackState : SkillState
{
    #region Projectile Variables
    public Transform attackPoint;
    public GameObject projectilePrefab;
    public DamageOnContact projectileDamage;
    float attackScaling;
    #endregion

    #region Status
    public StatusData selfBuff;
    public StatusData debuff;
    #endregion
    
    #region Angle Calculations
    public int numOfProjectiles;
    float angleSpread;
    float facingRotation;
    float startRotation;
    float angleIncrease;
    #endregion

    public ProjectileAttackState(Entity entity, EntityStateMachine stateMachine, EntityData data, string animParameterName, float skillDuration, float skillCooldown, GameObject projectilePrefab, float attackScaling, int numOfProjectiles, float angleSpread, string transformName) : base(entity, stateMachine, data, animParameterName, skillDuration, skillCooldown) {
        this.attackPoint = entity.transform.Find(transformName);
        this.projectilePrefab = projectilePrefab;
        projectilePrefab.GetComponent<DamageOnContact>().attacker = entity;
        this.numOfProjectiles = numOfProjectiles;
        this.angleSpread = angleSpread;
        angleIncrease = (angleSpread == 0 || numOfProjectiles == 0) ? 0 : angleSpread / numOfProjectiles;
        this.attackScaling = attackScaling;
    }

    public override void Enter() {
        Vector2 attackDirection = entity.attackDirection;
        facingRotation = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;
        startRotation = facingRotation - angleSpread / 2;
        base.Enter();
    }

    public override void Exit() {
        FireProjectiles();
        base.Exit();
    }

    public void UpdateNumberOfProjectiles(int newNumberOfProjectiles) {
        numOfProjectiles = newNumberOfProjectiles;
        angleIncrease = (angleSpread == 0 || numOfProjectiles == 0) ? 0 : angleSpread / (numOfProjectiles - 1);
    }

    void FireProjectiles() {
        for (int i = 0; i < numOfProjectiles; i++) {
            float rotation = startRotation + angleIncrease * i;
            GameObject newProjectile = GameObject.Instantiate(projectilePrefab, attackPoint.position, Quaternion.Euler(0f, 0f, rotation));
            newProjectile.SetActive(true);
            Projectile p = newProjectile.GetComponent<Projectile>();
            DamageOnContact d = newProjectile.GetComponent<DamageOnContact>();
            d.damage = entity.data.attackStat * attackScaling;
            if (p) p.Fire(new Vector2(Mathf.Cos(rotation * Mathf.Deg2Rad), Mathf.Sin(rotation * Mathf.Deg2Rad)));
        }
    }
}
