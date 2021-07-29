using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Text txtGraphics;
    private RenderingType renderingType;
    private void Awake()
    {
        renderingType = ApplicationData.Instance.RenderingType;
        switch (renderingType)
        {
            case RenderingType.Primitives:
                txtGraphics.text = "Graphics:  Primitives";
                break;
            case RenderingType.Sprites:
                txtGraphics.text = "Graphics:  Sprites";
                break;
        }
    }
    public void ButtonGraphicsPressed()
    {
        switch (renderingType)
        {
            case RenderingType.Sprites:
                renderingType = RenderingType.Primitives;
                txtGraphics.text = "Graphics:  Primitives";
                break;
            case RenderingType.Primitives:
                renderingType = RenderingType.Sprites;
                txtGraphics.text = "Graphics:  Sprites";
                break;
        }        
    }
    public void ButtonAcceptPressed()
    {
        var settings = ApplicationData.Instance.GetSettings();
        if (settings.RenderingType != renderingType)
        {
            SetSettings();
        }
        ButtonBackPressed();
    }

    public void ButtonBackPressed()
    {
        SceneManager.UnloadSceneAsync("Settings");
    }

    private void SetSettings()
    {
        ApplicationData.Instance.SetSettings(new GameSettings(renderingType));
    }
}
