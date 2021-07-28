using System;
using System.Linq;
using UnityEngine;

public class ApplicationSettings : MonoBehaviour
{
    public static ApplicationSettings Instacne;
    // Game
    public bool GameIsOn { get; private set; } = false;
    // - - - Render - - -
    // Action
    public event Action RenderChangeNotify;

    // Type
    public RenderingType RenderingType = RenderingType.Sprite;

    // Set rendering type
    public void SetRenderingType(RenderingType type)
    {
        if (!Enum.IsDefined(typeof(RenderingType), type))
        {
            throw new ArgumentException("Unknown render type: " + type);
        }

        RenderingType = type;

        var painters = FindObjectsOfType<MonoBehaviour>().OfType<IDrawn>().ToArray();
        foreach (var item in painters)
        {
            item.SetRenderType(RenderingType);
        }
    }

    private void Awake()
    {
        if (Instacne != null)
        {
            Instacne = this;
        }
        Destroy(gameObject);
    }
}
