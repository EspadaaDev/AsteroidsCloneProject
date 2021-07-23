using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
