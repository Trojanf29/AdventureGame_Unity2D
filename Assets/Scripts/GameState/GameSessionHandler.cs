using Assets.Scripts.StatelessData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

// Static handler for
//  - Invoking scripts whenever the first scene is loaded / debugged
//  - Handling game session
public class GameSessionHandler
{
    public const string SAVE_FILE_PATH = "savefile.dragon";
    public const int TOP_PROFILE = 5;

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

    public static bool IsAbleToSaveSession(int point)
    {
        var saveFile = File.Open(Path.Combine(Directory.GetCurrentDirectory(), SAVE_FILE_PATH), FileMode.OpenOrCreate);
        var formatter = new BinaryFormatter();
        var profiles = formatter.Deserialize(saveFile) as List<SaveProfile>;

        bool isAbleToSave = profiles.Any(_ => _.Point < point);
        saveFile.Close();
        return isAbleToSave;
    }

    public static List<SaveProfile> SaveSession(SaveProfile newProfile)
    {
        var saveFile = File.Open(Path.Combine(Directory.GetCurrentDirectory(), SAVE_FILE_PATH), FileMode.OpenOrCreate);
        var formatter = new BinaryFormatter();
        var profiles = formatter.Deserialize(saveFile) as List<SaveProfile>;

        var isAdded = AddProfileByHighScore(profiles, TOP_PROFILE, newProfile);
        if (isAdded)
        {
            formatter.Serialize(saveFile, profiles);
        }

        saveFile.Close();
        return profiles;
    }






    public class SaveProfile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Point { get; set; }
        public DateTime SavedTime { get; set; }

        public SaveProfile(string name, int point)
        {
            Id = Guid.NewGuid();
            Name = name;
            Point = point;
            SavedTime = DateTime.UtcNow;
        }
    }

    private static bool AddProfileByHighScore(List<SaveProfile> profiles, int topProfile, SaveProfile newProfile)
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