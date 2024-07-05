using System.Collections.Generic;
using System.Linq;
using UnityEngine;
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
    public static int Point { get; private set; }

    public LevelHandler()
    {
        Instance = this;
        ResetLevelHandler();
    }

    public static void ResetLevelHandler()
    {
        IsPaused = false;
        IsOver = false;
        Point = 0;
    }

    public void SetPoint(int point)
    {
        Point = point;
        PointText.text = "Point: " + point.ToString();
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
        GameOverMenu.SetActive(IsOver);
    }

    public void SaveHighScore()
    {
        //var profile = new GameSessionHandler.SaveProfile(string.Empty, Point);
        //var profiles = GameSessionHandler.SaveSession(profile);
        var profiles = new List<GameSessionHandler.SaveProfile>
        {
            new GameSessionHandler.SaveProfile(string.Empty, 100),
            new GameSessionHandler.SaveProfile(string.Empty, 90),
            new GameSessionHandler.SaveProfile(string.Empty, 40),
            new GameSessionHandler.SaveProfile(string.Empty, 50)
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