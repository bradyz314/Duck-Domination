using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] Entity player;
    Vector2 movementDirection;

    public void OnMove(InputAction.CallbackContext context) {
        // Update movementInput's value to one corresponding to user input if the Player can move
        if (context.performed) {
            movementDirection = context.ReadValue<Vector2>();
        } else if (context.canceled) {
            movementDirection = Vector2.zero;
        }
    }

    public void OnAttack(InputAction.CallbackContext context) {
       // If the player can Attack (Skills[0]) and is currently in a MovementState, update the state machine
        if (player.Skills[0].CheckIfSkillCanBeUsed() >= 0 && player.StateMachine.CurrentState.GetType().IsSubclassOf(typeof(MovementState))) {
            player.StateMachine.ChangeState(player.Skills[0]);
        }
    }

    public void OnSkill(InputAction.CallbackContext context) {
        // If the player can Skill (Skills[1]) and is currently in a MovementState, update the state machine
        if (player.Skills[1].CheckIfSkillCanBeUsed() >= 0 && player.StateMachine.CurrentState.GetType().IsSubclassOf(typeof(MovementState))) {
            player.StateMachine.ChangeState(player.Skills[1]);
        }
    }

    public void OnPause(InputAction.CallbackContext context) {
        if (context.performed) {
            PlayerUI.Instance.PauseGame();
        }
    }

    void FixedUpdate() {
        if (player.canMove) player.Rb.velocity = movementDirection * player.data.speed;
    }
}
