using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    private Animator anim;
    private BoxCollider2D coll;

    private const float Damage = 0.5f;

    private bool hit;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    private new void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.GetComponent<PlayerHealth>();
        if (player is not null && !hit)
        {
            player.TakeDamage(Damage);
        }

        hit = true;
        base.OnTriggerEnter2D(collider); //Execute logic from parent script first
        coll.enabled = false;

        if (anim != null)
        {
            anim.SetTrigger("Explode"); //When the object is a fireball explode it
        }
        else
            gameObject.SetActive(false); //When this hits any object deactivate arrow
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}