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
    public EnemyBase Get(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Asteroid:
                return Instantiate(asteroidPrefab);
            case EnemyType.SmallAsteroid:
                return Instantiate(smallAsteroidPrefab);
            case EnemyType.FlyingSaucer:
                return Instantiate(flyingSaucer);
        }
        return null;
    }


    void Start()
    {
    }
}
