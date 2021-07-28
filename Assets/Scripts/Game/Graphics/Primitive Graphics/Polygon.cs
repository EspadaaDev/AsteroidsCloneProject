using System.Linq;
using UnityEngine;

public class Polygon : MonoBehaviour
{
    public GameObject thatObject;
    private void Start()
    {
        // Create Vector2 vertices
        var vertices2D = thatObject.GetComponent<Collider2D>().CreateMesh(true, true).vertices;

       // var vertices3D = System.Array.ConvertAll<Vector2, Vector3>((vertices2D, v => v);

        // Use the triangulator to get indices for creating triangles
        var triangulator = new Triangulator(vertices2D);
        var indices = triangulator.Triangulate();

        // Generate a color for each vertex
        var colors = Enumerable.Range(0, vertices2D.Length)
            .Select(i => Color.white)
            .ToArray();

        // Create the mesh
        var mesh = new Mesh
        {
            vertices = vertices2D,
            triangles = indices,
            colors = colors
        };

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        // Set up game object with mesh;
        var meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Sprites/Default"));

        var filter = base.gameObject.AddComponent<MeshFilter>();
        filter.mesh = mesh;
    }
}
