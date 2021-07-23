using System;
using UnityEngine;

public class ObjectRenderer : MonoBehaviour, IPainter
{
    [SerializeField] private Sprite ObjectSprite;
    private SpriteRenderer spriteRenderer;
    private LineRenderer lineRenderer;

    [SerializeField] Vector2[] pointsForDraw;


    private void Awake()
    {
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = ObjectSprite;
        DrawLines();

        SetRenderType(ApplicationSettings.instance.RenderingType);
    }

    public void SetRenderType(RenderingType type)
    {
        if (!Enum.IsDefined(typeof(RenderingType), type))
        {
            throw new ArgumentException("Unknown rendering type: " + type);
        }
        else
        {
            switch (type)
            {
                case RenderingType.Sprite:
                    spriteRenderer.enabled = true;
                    lineRenderer.enabled = false;
                    break;
                case RenderingType.Polygon:
                    spriteRenderer.enabled = false;
                    lineRenderer.enabled = true;
                    break;                
            }
        }
    }

    private void DrawLines()
    {

    }
}
