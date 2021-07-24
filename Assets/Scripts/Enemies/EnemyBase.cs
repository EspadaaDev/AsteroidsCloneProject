using GameLogic.Architecture.Enemies;
using System;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public abstract event Action<int> DeathNofity;
    protected Enemy enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Bullet":
                Death(collision.tag);
                Destroy(collision.gameObject);
                break;
            case "LaserRay":
                Death(collision.tag);
                Destroy(collision.gameObject);
                break;
        }
    }

    protected abstract void Death(string projectileType);
}
