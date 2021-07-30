using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMethods : MonoBehaviour
{
    public GameObject PanelPause;

    // Pressing restart button
    public void ButtonRestartPreesed()
    {
        SceneManager.LoadScene("GameRoom", LoadSceneMode.Single);
    }

    // Pressing menu button
    public void ButtonMenuPreesed()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    // Pressing settings button
    public void ButtonSettingsPreesed()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Additive);
    }

    // Pressing resume button
    public void ButtonResumePreesed()
    {
        PanelPause.SetActive(false);
        ApplicationData.Instance.GameIsOn = true;
        Time.timeScale = 1;
    }

    // Pressing pause button
    public void ButtonPausePreesed()
    {
        Time.timeScale = 0;
        ApplicationData.Instance.GameIsOn = false;
        PanelPause.SetActive(true);
    }

    // Pressing exit button
    public void ButtonExitPresssed()
    {
        Application.Quit();
    }
}
