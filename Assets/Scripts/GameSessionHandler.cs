using Assets.Scripts.StatelessData;
using UnityEngine;

// Used to
//  - Invoke scripts whenever the first scene is loaded / debugged
//  - Handle game session
public class GameSessionHandler
{
    public static bool ResourceInited;

    public static string SelectedHero;
    public static int CurrentLevel;

    static GameSessionHandler()
    {
        SelectedHero = Constants.Selectable.MaskDude;
        Resource.Import();

        Debug.Log("Inited game session");
    }

    public void SaveSession()
    {

    }
}
