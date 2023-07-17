using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooterduck : Character
{
    [SerializeField] GameObject projectilePrefab;
    Camera cam;
    public ProjectileAttackState shootPistol;
    public ProjectileAttackState shootShotgun;

    protected new void Awake() {
        base.Awake();
        projectilePrefab = GameObject.Instantiate(projectilePrefab, gameObject.transform);
        projectilePrefab.SetActive(false);
        DamageOnContact d = projectilePrefab.GetComponent<DamageOnContact>();
        ProjectileUpgrade speedBuff = ((ProjectileUpgrade)(base.upgrades[2]));
        ProjectileUpgrade burnDebuff = ((ProjectileUpgrade)(base.upgrades[3]));
        if (speedBuff.applyStatus) d.selfBuffData = speedBuff.data;
        if (burnDebuff.applyStatus) d.debuffData = burnDebuff.data;        
        shootPistol = new ProjectileAttackState(this, StateMachine, data, "Attack", 0.183f, 1.5f, projectilePrefab, 1f, 1, 0f, "PistolPoint");
        shootShotgun = new ProjectileAttackState(this, StateMachine, data, "Attack", 0.350f, 3f, projectilePrefab, 0.5f, ((ProjectileUpgrade)(base.upgrades[1])).numOfProjectiles, 60f, "ShotgunPoint");
        base.Skills[0] = shootPistol;
        SkillState[] weapons = {shootPistol, shootShotgun};
        base.Skills[1] = new SwitchSkillState(this, StateMachine, data, null, 0, 5f, weapons, 0, "Pistol"); 
        cam = Camera.main;
    }

    public void UpdateAttackDirection() {
        Vector2 directionFromFirePoint = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - ((ProjectileAttackState)(base.Skills[0])).attackPoint.position; 
        directionFromFirePoint.Normalize();
        if ((facingRight && directionFromFirePoint.x > 0) || (!facingRight && directionFromFirePoint.x < 0)) {
            attackDirection = directionFromFirePoint;
        } else {
            attackDirection = new Vector2((facingRight ? 1 : -1), 0);
        }
    }
}
