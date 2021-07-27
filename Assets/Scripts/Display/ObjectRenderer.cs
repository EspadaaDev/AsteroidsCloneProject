using System;
using UnityEngine;

public class ObjectRenderer : MonoBehaviour, IDrawn
{
    [SerializeField] private Sprite ObjectSprite;
    private SpriteRenderer spriteRenderer;
    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;
    private LineRenderer lineRenderer;

    [SerializeField] Vector2[] pointsForDraw;


    private void Awake()
    {
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshFilter = gameObject.AddComponent<MeshFilter>();
        spriteRenderer.sprite = ObjectSprite;
        DrawLines();

        var bc = GetComponent<BoxCollider2D>();
        var mesh = bc.CreateMesh(true, true);
    }
    private void Start()
    {
         gameObject.GetComponent<MeshFilter>().mesh.Clear();
        gameObject.GetComponent<MeshFilter>().mesh.vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 0.25f, 0), new Vector3(0.25f, 0.25f, 0) };
        gameObject.GetComponent<MeshFilter>().mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 0.25f), new Vector2(0.25f, 0.25f) };
        gameObject.GetComponent<MeshFilter>().mesh.triangles = new int[] { 0, 1, 2 };
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
