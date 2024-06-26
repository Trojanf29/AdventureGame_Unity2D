using UnityEngine;
using System.Collections;
using Assets.Scripts.StatelessData;

public class Gift : MonoBehaviour
{
    // Drag the gameObject in Unity's Inspector
    public GameObject imageToShow;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Constants.GameObjects.Gift))
        {
            Destroy(other.gameObject);

            StartCoroutine(PauseGameAndShowImageForSeconds(10f));
        }
    }

    IEnumerator PauseGameAndShowImageForSeconds(float seconds)
    {
        Time.timeScale = 0f;

        imageToShow.SetActive(true);

        yield return new WaitForSecondsRealtime(seconds);

        imageToShow.SetActive(false);
        Time.timeScale = 1f;
    }
}
