using Assets.Scripts.StatelessData;
using UnityEngine;

// Static handler for
//  - Invoking scripts whenever the first scene is loaded / debugged
//  - Handling game session
public class GameSessionHandler
{
    public static bool ResourceInited;

    public static string SelectedHero;
    public static int CurrentLevel;

    static GameSessionHandler()
    {
        SelectedHero = Constants.Selectable.VirtualGuy;
        Resource.Import();

        Debug.Log("Inited game session");
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void SaveSession()
    {

    }
}
