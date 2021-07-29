using UnityEngine;

public class Ellipse : Figure
{
    public Ellipse(float figureSize, float figureFlattening, float figureTetaScale)
        : base(figureSize, figureFlattening, figureTetaScale) { }

    public override void Draw(ref LineRenderer lineRenderer)
    {
        var theta = 0f;
        var circleSize = (int)((1f / thetaScale) + 1f);
        lineRenderer.positionCount = circleSize;
        for (int i = 0; i < circleSize; i++)
        {
            theta += (2.0f * Mathf.PI * thetaScale);
            float x = size * Mathf.Cos(theta);
            float y = size * Mathf.Sin(theta) * flattening;
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}
