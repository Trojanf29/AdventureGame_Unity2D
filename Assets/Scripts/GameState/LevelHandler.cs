using UnityEngine;

// Static handler for
//  - Handling in-level events
public class LevelHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject PauseMenu;

    public static LevelHandler Instance { get; private set; }
    private static bool IsPaused;

    public LevelHandler()
    {
        Instance = this;
    }

    public void TogglePauseGame()
    {
        IsPaused = !IsPaused;
        PauseMenu.SetActive(IsPaused);

        Time.timeScale = IsPaused ? 0f : 1.0f;
    }

    public void QuitGame()
    {
        GameSessionHandler.QuitGame();
    }
}
