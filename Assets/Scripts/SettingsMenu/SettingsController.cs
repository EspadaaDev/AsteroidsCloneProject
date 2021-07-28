using UnityEngine.SceneManagement;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public void ButtonAcceptPressed()
    {
       
    }

    public void ButtonBackPressed()
    {
        SceneManager.UnloadSceneAsync("Settings");
    }
}
