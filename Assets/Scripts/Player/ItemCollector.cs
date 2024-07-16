using Assets.Scripts.StatelessData;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int score = 0;
    private int cherries = 0;

    [SerializeField]
    private AudioSource collectSoundEffect;
    [SerializeField]
    public Text scoreText;

    private void Start()
    {
        
        score = Pref.Score;
        UpdateScoreText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Constants.GameObjects.Cherry))
        {
            PlayerMovement playerMovement = GetComponent<PlayerMovement>();
            collectSoundEffect.Play();

            if (playerMovement != null)
            {
                Color randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                playerMovement.OnCherryCollected(randomColor);
            }

            Destroy(collision.gameObject);
            cherries++;
            score++;
            
            Pref.Score = score;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
