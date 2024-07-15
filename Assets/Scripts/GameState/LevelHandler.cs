using Assets.Scripts.StatelessData;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Static handler for
//  - Handling in-level events
public class LevelHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject PauseMenu;

    [SerializeField]
    private GameObject GameOverMenu;

    [SerializeField]
    private Text PointText;

    [SerializeField]
    private GameObject HighScoreMenu;

    public static LevelHandler Instance { get; private set; }

    private static bool IsPaused;
    private static bool IsOver;

    public LevelHandler()
    {
        Instance = this;
        ResetLevelHandler();
    }

    void Start()
    {
        Instance.UpdatePoint();
    }

    public static void ResetLevelHandler()
    {
        IsPaused = false;
        IsOver = false;
    }

    public void UpdatePoint()
    {
        PointText.text = "Point: " + GameSessionHandler.CurrentProfile.Point.ToString();

        // Save whenever the point changes
        GameSessionHandler.SaveSession();
    }

    public void TogglePauseGame()
    {
        IsPaused = !IsPaused;
        PauseMenu.SetActive(IsPaused);

        Time.timeScale = IsPaused ? 0f : 1.0f;
    }

    public void ToggleGameOver()
    {
        IsOver = !IsOver;
        if (IsOver)
        {
            GameSessionHandler.CurrentProfile.GameOver = true;
            GameSessionHandler.SaveSession();
        }

        GameOverMenu.SetActive(IsOver);
    }

    public void SaveHighScore()
    {
        // Default profiles
        var profiles = new List<Profile>
        {
            new Profile(
                string.Empty,
                Constants.Selectable.VirtualGuy,
                SceneManager.GetActiveScene().buildIndex,
                Constants.ProfileData.DefaultMaxHealth,
                Constants.ProfileData.DefaultCurrentHealth,
                70
            ) { SavedTime = new System.DateTime(2000, 1, 1) },
            new Profile(
                string.Empty,
                Constants.Selectable.VirtualGuy,
                SceneManager.GetActiveScene().buildIndex,
                Constants.ProfileData.DefaultMaxHealth,
                Constants.ProfileData.DefaultCurrentHealth,
                90
            ) { SavedTime = new System.DateTime(2001, 1, 1) },
            new Profile(
                string.Empty,
                Constants.Selectable.VirtualGuy,
                SceneManager.GetActiveScene().buildIndex,
                Constants.ProfileData.DefaultMaxHealth,
                Constants.ProfileData.DefaultCurrentHealth,
                40
            ) { SavedTime = new System.DateTime(2002, 1, 2) },
            new Profile(
                string.Empty,
                Constants.Selectable.VirtualGuy,
                SceneManager.GetActiveScene().buildIndex,
                Constants.ProfileData.DefaultMaxHealth,
                Constants.ProfileData.DefaultCurrentHealth,
                50
            ) { SavedTime = new System.DateTime(2003, 1, 3) },
            GameSessionHandler.CurrentProfile
        };

        var points = profiles.OrderByDescending(_ => _.Point).Select(_ => _.Point).ToList();
        var lines = new List<string>();
        int i = 0;
        for (i = 0; i < profiles.Count; i++)
        {
            lines.Add($"{i}. {points[i]}");
        }
        for (i = 5; i > profiles.Count; i--)
        {
            lines.Add($"{i}. ");
        }

        string highScoreText = string.Join("\r\n", lines);
        HighScoreMenu.transform.Find("HighScoreText").GetComponent<Text>().text = highScoreText;
        HighScoreMenu.SetActive(true);
    }

    public void QuitGame()
    {
        GameSessionHandler.QuitGame();
    }
}