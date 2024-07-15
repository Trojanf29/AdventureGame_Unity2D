using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pref 
{
    public static int CurPlayId;

    public static int Score;

    public static bool GetBool(string key)
    {
        return true;
        //return PlayerPrefs.GetInt(key) == 1 ? true : false;
    }
}
