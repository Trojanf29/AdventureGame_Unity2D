using System;
using System.Collections.Generic;

[Serializable]
public class SaveFile
{
    public List<Profile> HighScoreProfiles { get; set; } = new List<Profile>();
    public Profile CurrentProfile { get; set; }
}
