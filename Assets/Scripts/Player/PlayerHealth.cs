using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private AudioSource hurtSoundEffect;

    [SerializeField]
    private AudioSource deathSoundEffect;

    [SerializeField]
    public int startingHealth;

    [SerializeField]
    public BoxCollider2D BodyCollider;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    public int currentHealth { get; private set; }
    private bool isInvulnerable;
    //private bool isDead;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = startingHealth;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps") && collision.collider == BodyCollider)
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            //anim.SetTrigger("hurt");
            hurtSoundEffect.Play();

            // Become invunerability for a time
            StartCoroutine(Invunerability());
        }
        else
        {
            /*if (!isDead)
            {*/
                rb.bodyType = RigidbodyType2D.Static;
                //isDead = true;

                anim.SetTrigger("death");
                deathSoundEffect.Play();
            //}
        }
    }

    private IEnumerator Invunerability()
    {
        isInvulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < 3; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(1.5f / (3 * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(1.5f / (3 * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        isInvulnerable = false;
    }

    // Animation Event
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Animation Event
    private void OnDeathAnimationCompleted()
    {
        LevelHandler.Instance.ToggleGameOver();
    }
}
