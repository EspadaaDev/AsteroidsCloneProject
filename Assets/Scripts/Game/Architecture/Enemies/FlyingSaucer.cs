using GameLogic.Architecture.Enemies;
using UnityEngine;
using System;
using GameLogic.Architecture.Weapons.Projectiles;

public class FlyingSaucer : EnemyBase
{
    public override event Action<int> DeathPointsNofity;

    private Transform _player;

    protected override void Death(ProjectileType type)
    {
        DeathPointsNofity?.Invoke(Stats.PointsForDestroy);
        Destroy(gameObject);
    }
    private void Awake()
    {
        Stats = new EnemyStateProvider().GetStats(EnemyType.FlyingSaucer);
        _player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        if (_player != null) {
            Vector3 position = _player.position;
            transform.position = Vector3.MoveTowards(transform.position, position, 0.001f * Stats.MovementSpeed);
        }
    }


}
