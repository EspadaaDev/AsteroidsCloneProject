using UnityEngine;

public class Squre : Figure
{
    public Squre(float figureSize, float figureFlattening, float figureTetaScale)
        : base(figureSize, figureFlattening, figureTetaScale) { }

    public override void Draw(ref LineRenderer lineRenderer)
    {
        lineRenderer.positionCount = 4;

        Vector3[] vertexPositions = new Vector3[4] {
            new Vector3(1f, 1f * flattening, 0) * size,
            new Vector3(1f, -1f * flattening, 0)* size,
            new Vector3(-1f, -1f * flattening, 0)* size,
            new Vector3(-1f, 1f * flattening, 0)* size
        };
        lineRenderer.SetPositions(vertexPositions);
    }
}
