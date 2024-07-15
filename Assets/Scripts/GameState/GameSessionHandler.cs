using Assets.Scripts.StatelessData;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

// Static handler for
//  - Invoking scripts whenever the first scene is loaded / debugged
//  - Handling game session
public class GameSessionHandler
{
    public const string SAVE_FILE_PATH = "savefile.dragon";
    public const int TOP_PROFILE = 5;

    public static bool ResourceInited;
    public static Profile CurrentProfile { get; private set; }

    static GameSessionHandler()
    {
        Resource.Import();

        var savedProfile = LoadSaveFile().CurrentProfile;
        if (savedProfile is null || savedProfile.GameOver)
        {
            ResetProfile(Constants.Selectable.VirtualGuy);
            SaveSession();
        }
        else
        {
            CurrentProfile = savedProfile;
        }
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void ResetProfile(string selectedHero)
    {
        //
        CurrentProfile = new Profile(
            string.Empty,
            selectedHero,
            SceneManager.GetActiveScene().buildIndex,
            Constants.ProfileData.DefaultMaxHealth,
            Constants.ProfileData.DefaultCurrentHealth,
            0
        );
    }

    public static bool IsAbleToSaveSession(int point)
    {
        var saveFile = File.Open(Path.Combine(Directory.GetCurrentDirectory(), SAVE_FILE_PATH), FileMode.OpenOrCreate);
        var formatter = new BinaryFormatter();
        var profiles = formatter.Deserialize(saveFile) as List<Profile>;

        bool isAbleToSave = profiles.Any(_ => _.Point < point);
        saveFile.Close();
        return isAbleToSave;
    }

    public static SaveFile SaveSession()
    {
        var saveFileData = LoadSaveFile();
        TryAddProfileByHighScore(saveFileData.HighScoreProfiles, TOP_PROFILE, CurrentProfile);
        saveFileData.CurrentProfile = CurrentProfile;

        var saveFile = File.Open(Path.Combine(Directory.GetCurrentDirectory(), SAVE_FILE_PATH), FileMode.Create);
        new BinaryFormatter().Serialize(saveFile, saveFileData);

        saveFile.Close();
        return saveFileData;
    }

    public static SaveFile LoadSaveFile()
    {
        var saveFile = File.Open(Path.Combine(Directory.GetCurrentDirectory(), SAVE_FILE_PATH), FileMode.OpenOrCreate);
        if (saveFile.Length == 0)
        {
            saveFile.Close();
            return new SaveFile();
        }
        var formatter = new BinaryFormatter();
        var saveFileData = formatter.Deserialize(saveFile) as SaveFile;

        saveFile.Close();
        return saveFileData;
    }






    private static bool TryAddProfileByHighScore(List<Profile> profiles, int topProfile, Profile newProfile)
    {
        if (profiles.Count < topProfile)
        {
            profiles.Add(newProfile);
            return true;
        }

        var profileMinPoint = profiles.Min(_ => _.Point);
        if (profileMinPoint > newProfile.Point)
        {
            return false;
        }

        var removedProfile = profiles.OrderBy(_ => _.Point).ThenByDescending(_ => _.SavedTime).FirstOrDefault();
        profiles[profiles.IndexOf(removedProfile)] = newProfile;
        return true;
    }
}