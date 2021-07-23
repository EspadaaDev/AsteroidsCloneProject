using GameLogic.Architecture;
using GameLogic.Architecture.Enemies;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] GameObject smallAsteroidPrefab;
    [SerializeField] GameObject flyingSaucerPrefab;

    public static EnemyFactory instance;

    public Factory Factory;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CreateEmeny(EnemyType type)
    {
        
    }
}
