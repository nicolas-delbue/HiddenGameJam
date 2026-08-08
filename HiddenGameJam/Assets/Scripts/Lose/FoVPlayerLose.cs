using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public class FoVPlayerLose : MonoBehaviour
{
    [SerializeField] string PlayerTag;
    PolygonCollider2D polyCollider;
    private void Start()
    {
        Mesh mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;
        polyCollider = GetComponent<PolygonCollider2D>();

        float fov = 90f;
        Vector3 origin = Vector3.zero;
        int rayCount = 25;
        float angle = 0f;
        float angleIncrease = fov / rayCount;
        float viewDist = 5f;


        Vector3[] vertices = new Vector3[rayCount+1+1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount*3];

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 angleVertex = GetVectorFromAngle(angle);
            Vector3 vertex = origin + (angleVertex * viewDist);
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();

        Vector2[] v2 = new Vector2[vertices.Length];
        for(int i = 0; i < vertices.Length; i++)
        {
            Vector3 v3 = vertices[i];
            v2[i] = new Vector2(v3.x, v3.y);
        }
        polyCollider.SetPath(0, v2);
    }
    private Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            Debug.Log("Game Has Lost, Reset Map");
            //Game Lose Play animation? Reset
        }
    }
}
