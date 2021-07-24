using System;
using System.Linq;
using UnityEngine;

public class ApplicationSettings : MonoBehaviour
{
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

        var painters = FindObjectsOfType<MonoBehaviour>().OfType<IPainter>().ToArray();
        foreach (var item in painters)
        {
            item.SetRenderType(RenderingType);
        }
    }
}
