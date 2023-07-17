using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] string destroyParameter;
    [SerializeField] float fireForce;
    [SerializeField] bool hasDestroyAnimation;
    #region Components
    Animator animator;
    protected Rigidbody2D rb; 
    #endregion

    protected void Awake() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector2 direction) {
        rb.AddForce(new Vector3(direction.x, direction.y, 0) * fireForce, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other) {
        rb.velocity = Vector2.zero;
        if (hasDestroyAnimation) {
            PlayDestroyAnimation();
        } else {
            Destroy();
        }
    }

    protected void PlayDestroyAnimation() {
        animator.SetBool(destroyParameter, true);
    }

    public void Destroy() {
        GameObject.Destroy(this.gameObject);
    }
}
