using GameLogic.Architecture.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    private EnemyFactory factory;
    // Start is called before the first frame update
    void Start()
    {
        factory = GetComponent<EnemyFactory>();
        var a = factory.Get(EnemyType.Asteroid);
        a.DeathNofity += DieEnemyLog;
    }

    private void DieEnemyLog(int points)
    {
        Debug.Log(points);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
