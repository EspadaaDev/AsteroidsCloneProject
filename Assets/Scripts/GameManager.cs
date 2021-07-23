using UnityEngine;
using GameLogic.Player;
using GameLogic.Architecture;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;
    // Player
    [SerializeField] private GameObject playerPrefab;
    private PlayerController playerController;

    // Factory
    private Factory factory;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Enemies

    // Start is called before the first frame update
    void Start()
    {
        factory = new Factory();
        // Player instanciate
        var playerObject = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private IEnumerator EnemyFactoryMethod()
    {

        yield return null;
    }
}
