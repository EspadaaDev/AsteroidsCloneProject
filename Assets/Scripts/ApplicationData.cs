using System;
using UnityEngine;

public class ApplicationData : MonoBehaviour
{
    // Singleton
    public static ApplicationData Instance { get; private set; }
    public PlayerPrefsLoader DataLoader;
    // App data
    public int BestScore { get; private set; }
    public bool GameIsOn { get; set; } = false;

    // App settings
    private RenderingType renderingType = RenderingType.Sprites;

    // Events
    public event Action ChangeRenderingType;
    public event Action<bool> ChangeIsMusicPlays;
    public event Action<bool> ChangeIsSoundsPlays;

    public RenderingType RenderingType
    {
        get { return renderingType; }
        private set
        {
            renderingType = value;
            ChangeRenderingType?.Invoke();
        }
    }   

    // Methods
    // Set settings
    public void SetSettings(GameSettings settings)
    {
        RenderingType = settings.RenderingType;
    }
    public GameSettings GetSettings()
    {
        return new GameSettings(RenderingType);
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Init();
            Instance = this;
        }
        Destroy(gameObject);
    }
    private void Init()
    {
        DataLoader = new PlayerPrefsLoader();
        BestScore = DataLoader.GetBestScore();
    }

    public void SetBestScore(int value)
    {
        if (DataLoader.SetBestScore(value))
        {
            BestScore = DataLoader.GetBestScore();
        }
    }
}
