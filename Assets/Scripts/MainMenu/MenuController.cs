using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text txtBestScore;
    private void Awake()
    {
        Time.timeScale = 1;
        txtBestScore.text = ApplicationData.Instance.BestScore.ToString();
    }
}
