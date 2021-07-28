using GameLogic.Architecture.Enemies;
using GameLogic.Architecture.Weapons.Projectiles;
using System;
using UnityEngine;

public class Asteroid : EnemyBase
{
    public override event Action<int> DeathPointsNofity;
    public  event Action<ProjectileType, Vector3> DeathNofity;

    private void Awake()
    {
        Stats = new EnemyStateProvider().GetStats(EnemyType.Asteroid);
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 50f);
    }
    protected override void Death(ProjectileType type)
    {
        DeathPointsNofity?.Invoke(Stats.PointsForDestroy);
        DeathNofity?.Invoke(type, transform.position);
        Destroy(gameObject);
    }
}
