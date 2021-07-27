using System;
using System.Collections;
using UnityEngine;

public class LaserRay
{
    LaserView laserView;
    Transform player;
    public LaserRay(LineRenderer renderer, Transform transform)
    {
        player = transform;
        laserView = new LaserView(renderer, transform);
    }
    public void Shot()
    {
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, player.transform.up, 10f);
        laserView.Draw();
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Enemy")
            {
                ////////////TODO
                hit.collider.gameObject.GetComponent<EnemyBase>();
            }
        }
    }

    private void StartCorutine(IEnumerator enumerator)
    {
        throw new NotImplementedException();
    }
}
