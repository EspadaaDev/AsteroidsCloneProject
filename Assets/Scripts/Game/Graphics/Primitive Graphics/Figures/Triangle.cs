using UnityEngine;

public class Triangle : Figure
{  
    public Triangle(float figureSize, float figureFlattening, float figureTetaScale)
        : base(figureSize, figureFlattening, figureTetaScale) { }

    public override void Draw(ref LineRenderer lineRenderer)
    {
        lineRenderer.positionCount = 3;
        Vector3[] vertexPositions = new Vector3[3] {
            new Vector3(1f, -1f * flattening, 0) * size,
            new Vector3(0, 1f * flattening, 0) * size,
            new Vector3(-1f, -1f * flattening, 0)* size
        };

        lineRenderer.SetPositions(vertexPositions);
    }
}
