using GameLogic.Architecture.Enemies;
using GameLogic.Architecture.Weapons.Projectiles;
using System;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public abstract event Action<int> DeathPointsNofity;
    protected Enemy enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Bullet":
                Death(ProjectileType.Bullet);
                Destroy(collision.gameObject);
                break;
            case "LaserRay":
                Death(ProjectileType.LaserRay);
                break;
        }
    }

    protected abstract void Death(ProjectileType type);
}
