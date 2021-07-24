using GameLogic.Architecture.Enemies;
using System;
using System.Collections;
using UnityEngine;

public class Asteroid : EnemyBase
{
    public override event Action<int> DeathNofity;

    private void Awake()
    {
        enemy = new Enemy(EnemyType.Asteroid);
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 10f);
    }
    protected override void Death(string projectileType)
    {
        DeathNofity?.Invoke(enemy.Stats.PointsForDestroy);
        Destroy(gameObject);
    }
}
