using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameBoard board;
    [SerializeField] private GUIController gui;
    private PlayerController player;

    private void Start()
    {
        ApplicationData.Instance.GameIsOn = true;
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerController>();
        player.GameOverNotify += GameOver;
    }

    private void GameOver()
    {
        ApplicationData.Instance.GameIsOn = false;
        Time.timeScale = 0;
        gui.ShowGameOverPanel(board.Score.Count);
    }
}
