using UnityEngine;

public class PrimitiveRenderer : MonoBehaviour
{
    [Header("Renderer settings:")]    
    [SerializeField, Range(0.01f, 1f)] private float lineThickness = 0.03f;
    [SerializeField] private Material material;
    [Header("Figure settings:")]
    [SerializeField] private FigureType figureType;
    [SerializeField, Range(0.001f, 10f)] private float size = 0.4f;
    [SerializeField, Range(0.01f, 1f)] private float thetaScale = 0.01f;
    [SerializeField, Range(0.01f, 100f)] private float flattening = 1.0f;

    private Figure figure;
    private LineRenderer lineRenderer;
    private void Awake()
    {
        SetFigure();
    }
    private void Start()
    {
        SetLineRenderer();
    }

    private void SetLineRenderer()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.loop = true;
        lineRenderer.useWorldSpace = false;
        lineRenderer.startWidth = lineThickness;
        lineRenderer.startWidth = lineThickness;
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.material = material;
    }

    private void SetFigure()
    {
        switch (figureType)
        {
            case FigureType.ellipse:
                figure = new Ellipse(size, flattening, thetaScale);
                break;
            case FigureType.sqare:
                figure = new Squre(size, flattening, thetaScale);
                break;
            case FigureType.triangle:
                figure = new Triangle(size, flattening, thetaScale);
                break;
        }
    }

    private void Update()
    {
        figure.Draw(ref lineRenderer);
    }
}
