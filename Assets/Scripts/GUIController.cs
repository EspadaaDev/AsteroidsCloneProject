using GameLogic.Architecture.Weapons.Guns;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    [SerializeField] private GameBoard gameBoard;
    [SerializeField] private PlayerController player;
    [Header("GUI:")]
    public Text txtScore;
    public Text txtLaserShots;

    public void ScoreUpdate(int points)
    {
        txtScore.text = points.ToString();
    }

    public void LaserShotsUpdate(float shots)
    {
        txtLaserShots.text = ((int)shots).ToString() + " \\ " + player.Laser.MaximumShots.ToString();
    }

    private void Start()
    {
        gameBoard.Score.ScoreChangeNotify += ScoreUpdate;
        player.Laser.NumOfShotsHandler += LaserShotsUpdate;
    }
}
