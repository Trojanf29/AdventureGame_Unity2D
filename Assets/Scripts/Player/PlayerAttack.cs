using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private BoxCollider2D attackRange;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    private bool IsAttacking = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack()
            && Time.timeScale > 0)
        {
            IsAttacking = true;
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy") && IsAttacking)
        {
            Debug.Log("Inflict damage!");
        }
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
    }

    private void AttackComplete()
    {
        Debug.Log("caled");
        IsAttacking = false;
    }
}
