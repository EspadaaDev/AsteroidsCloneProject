using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMethods : MonoBehaviour
{
    public GameObject PanelPause;
    public void ButtonRestartPreesed()
    {
        SceneManager.LoadScene("GameRoom", LoadSceneMode.Single);
    }
    public void ButtonMenuPreesed()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void ButtonSettingsPreesed()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Additive);
    }
    public void ButtonResumePreesed()
    {
        PanelPause.SetActive(false);
        ApplicationData.Instance.GameIsOn = true;
        Time.timeScale = 1;
    }
    public void ButtonPausePreesed()
    {
        Time.timeScale = 0;
        ApplicationData.Instance.GameIsOn = false;
        PanelPause.SetActive(true);
    }
}
