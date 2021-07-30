using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Text txtGraphics;
    private RenderingType renderingType;

    private void Awake()
    {
        // Set text values of settings
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

    // Pressing on the change graphics button
    public void ButtonGraphicsPressed()
    {
        // Change of graphics type
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

    // Applying settings changes
    public void ButtonAcceptPressed()
    {
        var settings = ApplicationData.Instance.GetSettings();
        if (settings.RenderingType != renderingType)
        {
            SetSettings();
        }
        ButtonBackPressed();
    }

    // Pressing the back button
    public void ButtonBackPressed()
    {
        SceneManager.UnloadSceneAsync("Settings");
    }

    // Setting settings
    private void SetSettings()
    {
        ApplicationData.Instance.SetSettings(new GameSettings(renderingType));
    }
}
