using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserView
{
    private LineRenderer lineRenderer;
    private Transform player;
    public LaserView(LineRenderer renderer, Transform transform)
    {
        lineRenderer = renderer;
        player = transform;
    }
    public void Draw()
    {
        DrawCorutine();
    }

    private IEnumerator DrawCorutine()
    {
        lineRenderer.SetPosition(0, player.transform.position + new Vector3(0, 0, 0));
        lineRenderer.SetPosition(1, player.transform.up * 5000);
        yield return new WaitForSeconds(0.3f);
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.zero);
    }
}
