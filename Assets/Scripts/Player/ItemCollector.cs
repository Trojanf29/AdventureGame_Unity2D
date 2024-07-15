using Assets.Scripts.StatelessData;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField]
    private AudioSource collectSoundEffect;

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
            GameSessionHandler.CurrentProfile.Point++;
            LevelHandler.Instance.UpdatePoint();
        }
    }
}
