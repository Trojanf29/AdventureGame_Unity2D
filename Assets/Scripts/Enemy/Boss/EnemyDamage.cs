using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    protected float damage;

    protected void OnTriggerEnter2D(Collider2D collission)
    {
        if (collission.tag == "Player")
            collission.GetComponent<EnemyHealth>().TakeDamage(damage);
    }
}
