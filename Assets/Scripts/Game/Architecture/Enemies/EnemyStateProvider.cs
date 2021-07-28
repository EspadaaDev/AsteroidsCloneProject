using GameLogic.Architecture.Enemies;

public class EnemyStateProvider
{
    public EnemyStats GetStats(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Asteroid:
                return new EnemyStats(50f, 100);

            case EnemyType.SmallAsteroid:
                return new EnemyStats(70f, 150);

            case EnemyType.FlyingSaucer:
                return new EnemyStats(30f, 400);
        }
        return null;
    }
}
