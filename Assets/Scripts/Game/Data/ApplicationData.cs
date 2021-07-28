using System;
using UnityEngine;

public class ApplicationData : MonoBehaviour
{
    // Singleton
    public static ApplicationData Instance { get; private set; }

    // App data
    public int BestScore { get; }
    public bool GameIsOn { get; set; } = false;

    // App settings
    // Events
    public event Action<RenderingType> ChangeRenderingType;
    public event Action<bool> ChangeIsMusicPlays;
    public event Action<bool> ChangeIsSoundsPlays;
    public RenderingType RenderingType
    {
        get { return RenderingType; }
        private set
        {
            RenderingType = value;
            ChangeRenderingType?.Invoke(RenderingType);
        }
    }
    public bool IsMusicPlays
    {
        get { return IsMusicPlays; }
        private set
        {
            IsMusicPlays = value;
            ChangeIsMusicPlays?.Invoke(IsMusicPlays);
        }
    }
    public bool IsSoundsPlays
    {
        get { return IsSoundsPlays; }
        private set
        {
            IsSoundsPlays = value;
            ChangeIsSoundsPlays?.Invoke(IsMusicPlays);
        }
    }

    // Methods
    // Set settings
    public void SetSettings(RenderingType type, bool isMusicPlays, bool isSoundsPlays)
    {
        if (RenderingType != type)
        {
            RenderingType = type;
        }
        if (IsMusicPlays != IsMusicPlays)
        {
            IsMusicPlays = isMusicPlays;
        }
        if (IsSoundsPlays != isSoundsPlays)
        {
            IsSoundsPlays = isSoundsPlays;
        }
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

    }
}
