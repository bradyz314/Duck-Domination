using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Entity enemy;
    Vector2 movementDirection; 
    public bool moveTowardsPlayer;

    public LayerMask playerLayer;
    public float enemyDetectionRange;
    public float[] skillRanges;

    public void Move() {
        movementDirection = CheckPlayerInRange(enemyDetectionRange);
        if (!moveTowardsPlayer) {
            movementDirection = new Vector2(movementDirection.x, -movementDirection.y);
        }
    }

    public bool UseSkill() {
        if (enemy.StateMachine.CurrentState.GetType().IsSubclassOf(typeof(MovementState))) {
            for (int i = skillRanges.Length - 1; i >= 0; i--) {
                if (enemy.Skills[i].CheckIfSkillCanBeUsed() >= 0) {
                    enemy.attackDirection = CheckPlayerInRange(skillRanges[i]);
                    if (enemy.attackDirection != Vector2.zero) {
                        enemy.StateMachine.ChangeState(enemy.Skills[i]);
                        return true;
                    }
                }
            }
        }
        return false;
    }

    Vector2 CheckPlayerInRange(float range) {
        Collider2D playerCollider = Physics2D.OverlapCircle(enemy.transform.position, range, playerLayer);
        if (playerCollider != null) {
            Vector3 direction = playerCollider.transform.position - enemy.transform.position;
            direction.Normalize();  
            return new Vector2(direction.x, direction.y);
        } else {
            return Vector2.zero;
        }
    }

    void FixedUpdate() {
        if (enemy.canMove) {
            if (!UseSkill()) {
                Move();
                enemy.Rb.velocity = movementDirection * enemy.data.speed;
            }
       }
    }
}
