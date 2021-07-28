using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveRenderer : MonoBehaviour, IRender
{
    [Range(0.1f, 100f)]
    public float radius = 1.0f;

    [Range(3, 256)]
    public int numSegments = 128;

    public Material MaterialRender;
    void Start()
    {
        DoRenderer();
    }

    public void DoRenderer()
    {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        Color c1 = new Color(255, 255, 255, 1);
        lineRenderer.material = MaterialRender;
        lineRenderer.SetColors(c1, c1);
        lineRenderer.SetWidth(0.5f, 0.5f);
        lineRenderer.SetVertexCount(numSegments + 1);
        lineRenderer.useWorldSpace = false;

        float deltaTheta = (float)(2.0 * Mathf.PI) / numSegments;
        float theta = 0f;

        for (int i = 0; i < numSegments + 1; i++)
        {
            float x = radius * Mathf.Cos(theta);
            float z = radius * Mathf.Sin(theta);
            Vector3 pos = new Vector3(z, x, 0);
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }
    public void Draw()
    {
        throw new System.NotImplementedException();
    }
}
