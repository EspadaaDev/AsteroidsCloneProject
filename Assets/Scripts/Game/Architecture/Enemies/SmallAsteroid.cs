using GameLogic.Architecture.Enemies;
using GameLogic.Architecture.Weapons.Projectiles;
using System;
using UnityEngine;

public class SmallAsteroid : EnemyBase
{
    public override event Action<int> DeathPointsNofity;

    protected override void Death(ProjectileType type)
    {
        DeathPointsNofity?.Invoke(Stats.PointsForDestroy);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Awake()
    {
        Stats = new EnemyStateProvider().GetStats(EnemyType.SmallAsteroid);
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 65f);
    }
}
