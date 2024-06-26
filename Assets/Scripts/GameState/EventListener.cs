using UnityEngine;

// Singleton handler for
//  - Listening to input events
public class EventListener : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LevelHandler.Instance.TogglePauseGame();
        }
    }
}
