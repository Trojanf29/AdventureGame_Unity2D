using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        GameSessionHandler.QuitGame();
    }

    public void TogglePauseGame()
    {
        LevelHandler.Instance.TogglePauseGame();
    }
}
