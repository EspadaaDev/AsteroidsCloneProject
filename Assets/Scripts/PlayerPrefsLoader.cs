using UnityEngine;

public class PlayerPrefsLoader
{
    // Getting best score from player prefs
    public int GetBestScore()
    {
        if (!PlayerPrefs.HasKey("best_score"))
        {
            return 0;
        }
        return PlayerPrefs.GetInt("best_score");
    }

    // Setting best score in player prefs
    public bool SetBestScore(int value)
    {
        if (!PlayerPrefs.HasKey("best_score") || PlayerPrefs.GetInt("best_score") < value)
        {
            PlayerPrefs.SetInt("best_score", value);
            return true;
        }
        return false;
    }
}

public struct GameSettings
{
    public RenderingType RenderingType { get; private set; }

    public GameSettings(RenderingType type)
    {
        RenderingType = type;
    }
}



