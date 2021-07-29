using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    [SerializeField] private float timerTransition = 3.0f;
    // Update is called once per frame
    void Update()
    {
        timerTransition -= Time.deltaTime;
        if (timerTransition <= 0)
        {
            LoadingIsComplete();
        }
    }

    private void LoadingIsComplete()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
