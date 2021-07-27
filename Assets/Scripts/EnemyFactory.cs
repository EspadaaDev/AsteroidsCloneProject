using GameLogic.Architecture.Enemies;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField]
    private EnemyBase asteroidPrefab;
    [SerializeField]
    private EnemyBase smallAsteroidPrefab;
    [SerializeField]
    private EnemyBase flyingSaucer;

    // Return enemy prefab from type
    public EnemyBase Get(EnemyType type, Vector2 position, Quaternion quaternion)
    {
        switch (type)
        {
            case EnemyType.Asteroid:
                return Instantiate(asteroidPrefab, position, quaternion);
            case EnemyType.SmallAsteroid:
                return Instantiate(smallAsteroidPrefab, position, quaternion);
            case EnemyType.FlyingSaucer:
                return Instantiate(flyingSaucer, position, quaternion);
        }
        return null;
    }


    void Start()
    {
    }
}
