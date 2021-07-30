using GameLogic.Architecture;
using GameLogic.Architecture.Enemies;
using GameLogic.Architecture.Weapons.Projectiles;
using System.Collections;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [Header("Enemy spawn borders:")]
    [SerializeField]
    private Vector2 spawnBorder = new Vector2(9f, 5f);
    [SerializeField]
    private float spawnIndent = 4.5f;

    [Header("Object creation time:")]
    [SerializeField]
    private Vector2 asteroidCreationTime = new Vector2(1f, 3f);
    [SerializeField]
    private Vector2 smallAsteroidCreationTime = new Vector2(3f, 6f);
    [SerializeField]
    private Vector2 flyingSaucerCreationTime = new Vector2(15f, 20f);

    [Header("Other: ")]
    public Transform Player;
    public Score Score;

    private EnemyFactory _factory;
    private SpawnMath _spawnMath;



    // Private methods
    // Game
    private void Awake()
    {
        _factory = GetComponent<EnemyFactory>();
        _spawnMath = new SpawnMath(spawnBorder, spawnIndent);
        Score = new Score();
    }

    private void Start()
    {
        ApplicationData.Instance.GameIsOn = true;
        StartCoroutine(InstantiateAsteroidsLogic());
        StartCoroutine(InstantiateFlyingSaucerLogic());
        StartCoroutine(InstantiateSmallAsteroidsLogic());
    }

    private void Update()
    {
        PlayerBorderTeleport();
    }

    // The logic of the appearance of Asteroids
    private IEnumerator InstantiateAsteroidsLogic()
    {
        while (ApplicationData.Instance.GameIsOn)
        {

            yield return new WaitForSeconds(Random.Range(asteroidCreationTime.x, asteroidCreationTime.y));

            var createPosition = _spawnMath.GetRandomSpawnPosition();
            Asteroid temp = _factory.Get(EnemyType.Asteroid, createPosition, _spawnMath.GetRandomQuaternionToCenter(createPosition)).GetComponent<Asteroid>();
            temp.DeathNofity += OnAsteroidDeath;
            temp.DeathPointsNofity += Score.Add;
        }
    }

    // The logic of the appearance of flying saucers
    private IEnumerator InstantiateFlyingSaucerLogic()
    {
        while (ApplicationData.Instance.GameIsOn)
        {

            yield return new WaitForSeconds(Random.Range(flyingSaucerCreationTime.x, flyingSaucerCreationTime.y));

            var createPosition = _spawnMath.GetRandomSpawnPosition();
            EnemyBase temp = _factory.Get(EnemyType.FlyingSaucer, createPosition, Quaternion.identity).GetComponent<EnemyBase>();
            temp.DeathPointsNofity += Score.Add;
        }
    }

    //The logic of the appearance of small asteroids
    private IEnumerator InstantiateSmallAsteroidsLogic()
    {
        while (ApplicationData.Instance.GameIsOn)
        {
            yield return new WaitForSeconds(Random.Range(smallAsteroidCreationTime.x, smallAsteroidCreationTime.y));

            var createPosition = _spawnMath.GetRandomSpawnPosition();
            EnemyBase temp = _factory.Get(EnemyType.SmallAsteroid, createPosition,
                _spawnMath.GetRandomQuaternionToCenter(createPosition)).GetComponent<EnemyBase>();
            temp.DeathPointsNofity += Score.Add;
        }
    }

    // At the death of an asteroid
    private void OnAsteroidDeath(ProjectileType type, Vector3 position)
    {
        if (type == ProjectileType.Bullet)
        {
            EnemyBase temp = _factory.Get(EnemyType.SmallAsteroid, position,
                _spawnMath.GetRandomQuaternionToCenter(position));
            temp.DeathPointsNofity += Score.Add;
            temp = _factory.Get(EnemyType.SmallAsteroid, position, _spawnMath.GetRandomQuaternionToCenter(position));
            temp.DeathPointsNofity += Score.Add;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Destroying all objects when going abroad
        Destroy(collision.gameObject);        
    }

    // Teleport the player at the borders
    private void PlayerBorderTeleport()
    {
        if (Mathf.Abs(spawnBorder.x * 1.05f) < Mathf.Abs(Player.position.x))
        {
            Player.position = new Vector3(-Player.position.x * 0.98f, Player.position.y, 0);
        }
        if (Mathf.Abs(spawnBorder.y * 1.05f) < Mathf.Abs(Player.position.y))
        {
            Player.position = new Vector3(Player.position.x, -Player.position.y * 0.98f, 0);
        }
    }
}
