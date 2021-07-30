using System;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    [SerializeField] private GameBoard gameBoard;
    [SerializeField] private PlayerController player;

    [Header("GUI:")]
    [SerializeField] private Text TxtScore;
    [SerializeField] private Text TxtBestScore;
    [Header("Info Panel:")]
    [SerializeField] private Text TxtLaserShots;
    [SerializeField] private Text TxtXCoordinate;
    [SerializeField] private Text TxtYCoordinate;
    [SerializeField] private Text TxtAngle;
    [SerializeField] private Text TxtSpeed;
    [SerializeField] private Text TxtReloadLaserTimer;
    [SerializeField] private Image ReloadLaserProgressBar;

    [Header("Others:")]
    [SerializeField] private Text TxtLastScore;
    [SerializeField] private GameObject PanelGameOver;

    private Rigidbody2D rbPlayer;
    private float timerToReloadLaser = 0;



    private void Start()
    {
        gameBoard.Score.ScoreChangeNotify += ScoreUpdate;
        rbPlayer = player.gameObject.GetComponent<Rigidbody2D>();
        TxtBestScore.text = "BEST:  " + ApplicationData.Instance.BestScore.ToString();
    }

    private void Update()
    {
        InfoPanelUpdate();
    }

    // Updating the points obtained during the game
    private void ScoreUpdate(int points)
    {
        TxtScore.text = points.ToString();
    }

    // Updating the current number of laser shots
    private void LaserShotsUpdate()
    {
        TxtLaserShots.text = ((int)player.Laser.NumOfShots).ToString() + " \\ " + player.Laser.MaximumShots.ToString();
    }

    // The method displays game end panel and sets the value of scored points
    public void ShowGameOverPanel(int value)
    {
        PanelGameOver.SetActive(true);
        TxtLastScore.text = "Score: " + value.ToString();
    }

    // Updating dashboard components
    private void InfoPanelUpdate()
    {
        // Coordinates
        TxtXCoordinate.text = "X: " + (Math.Round(player.transform.position.x, 1) * 10f).ToString();
        TxtYCoordinate.text = "Y: " + (Math.Round(player.transform.position.y, 1) * 10f).ToString();

        // Speed and angle of spaceship
        TxtSpeed.text = "Speed: " + (Math.Round(rbPlayer.velocity.magnitude, 2) * 10f).ToString();
        TxtAngle.text = "Angle: " + Math.Round(player.transform.rotation.eulerAngles.z, 0).ToString()+ "°";

        LaserShotsUpdate();
        ReloadInfoUpdate();
    }

    // Laser reload information update
    private void ReloadInfoUpdate()
    {

        if (player.Laser.NumOfShots < player.Laser.MaximumShots)
        {
            if (timerToReloadLaser < player.Laser.AddShotTime)
            {
                timerToReloadLaser += Time.deltaTime;
                TxtReloadLaserTimer.text = Math.Round(timerToReloadLaser, 2).ToString();
            }
            else
            {
                timerToReloadLaser = 0;
            }
        }
        else
        {
            timerToReloadLaser = player.Laser.AddShotTime;
            TxtReloadLaserTimer.text = player.Laser.AddShotTime.ToString() + ".00";
        }

        ReloadLaserProgressBar.fillAmount = timerToReloadLaser / player.Laser.AddShotTime;
    }
}
