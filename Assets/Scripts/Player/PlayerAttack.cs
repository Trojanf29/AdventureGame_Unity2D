using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float attackCooldown;
    [SerializeField]
    private BoxCollider2D attackRange;

    private const int Damage = 1;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    private bool IsAttacking = false;
    private List<Collider2D> attackedEnemies = new List<Collider2D>();

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (anim.runtimeAnimatorController.name != "Hero")
            return;

        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack() && IsAttacking == false)
        {
            IsAttacking = true;
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy") && !attackedEnemies.Contains(collider) && IsAttacking)
        {
            attackedEnemies.Add(collider);
            collider.GetComponent<EnemyHealth>().TakeDamage(Damage);
        }
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
    }

    public void AttackComplete()
    {
        IsAttacking = false;
        attackedEnemies.Clear();
    }
}
