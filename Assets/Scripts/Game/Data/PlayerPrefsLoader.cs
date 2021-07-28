using UnityEngine;

public class PlayerPrefsLoader
{
    public int GetBestScore()
    {
        return 1;
    }

    public void SetBestScore()
    {

    }

    public GameSettings GetSettings()
    {
        return new GameSettings();
    }
    public void SetSettings()
    {

    }
}

public struct GameSettings
{
    public RenderingType RenderingType { get; private set; }
    public bool IsMusicPlays { get; private set; }
    public bool IsSoundsPlays { get; private set; }

    public GameSettings(RenderingType type, bool music, bool sounds)
    {
        RenderingType = type;
        IsMusicPlays = music;
        IsSoundsPlays = sounds;
    }
}



