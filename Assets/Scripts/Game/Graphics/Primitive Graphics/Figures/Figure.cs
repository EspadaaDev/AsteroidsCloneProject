using UnityEngine;

public abstract class Figure
{
    protected float size;
    protected float thetaScale;
    protected float flattening;

    public Figure(float figureSize, float figureFlattening, float figureTetaScale)
    {
        size = figureSize;
        thetaScale = figureTetaScale;
        flattening = figureFlattening;
    }

    public abstract void Draw(ref LineRenderer lineRenderer);
}
