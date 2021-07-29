using UnityEngine;

public class PlayerPrefsLoader
{
    public int GetBestScore()
    {
        if (!PlayerPrefs.HasKey("best_score"))
        {
            return 0;
        }
        return PlayerPrefs.GetInt("best_score");
    }

    public bool SetBestScore(int value)
    {
        if (!PlayerPrefs.HasKey("best_score") || PlayerPrefs.GetInt("best_score") < value)
        {
            PlayerPrefs.SetInt("best_score", value);
            return true;
        }
        return false;
    }

    public GameSettings GetSettings()
    {
        return new GameSettings();
    }

    public void SetSettings(RenderingType type)
    {
        ApplicationData.Instance.SetSettings(new GameSettings(type));
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



