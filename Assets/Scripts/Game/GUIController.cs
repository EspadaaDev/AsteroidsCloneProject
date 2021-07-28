using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    [SerializeField] private GameBoard gameBoard;
    [SerializeField] private PlayerController player;
    [Header("GUI:")]
    public Text TxtScore;
    public Text TxtLaserShots;

    public GameObject PanelGameOver;
    public Text TxtLastScore;

    private void ScoreUpdate(int points)
    {
        TxtScore.text = points.ToString();
    }

    private void LaserShotsUpdate(float shots)
    {
        TxtLaserShots.text = ((int)shots).ToString() + " \\ " + player.Laser.MaximumShots.ToString();
    }

    private void Start()
    {
        gameBoard.Score.ScoreChangeNotify += ScoreUpdate;
        player.Laser.NumOfShotsHandler += LaserShotsUpdate;
    }

    public void ShowGameOverPanel(int value)
    {
        PanelGameOver.SetActive(true);
        TxtLastScore.text = "Score: " + value.ToString();
    }    
}
