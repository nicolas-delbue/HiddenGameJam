using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public class FoVPlayerLose : MonoBehaviour
{
    [SerializeField] string PlayerTag;
    [SerializeField] LayerMask layer;
    MeshFilter filter;
    PolygonCollider2D polyCollider;
    private Mesh myMesh;
    private bool doOnce = false;

    private void Start()
    {
        myMesh = new Mesh();

        filter = GetComponent<MeshFilter>();
        filter.mesh = myMesh;
        polyCollider = GetComponent<PolygonCollider2D>();
        doOnce = false;
    }
    private void Update()
    {
        float fov = 90f;
        Vector3 origin = Vector3.zero;
        int rayCount = 25;
        float angle = 0f;
        float viewDist = 5f;
        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            Vector3 angleVertex = GetVectorFromAngle(angle);
            RaycastHit2D hit = Physics2D.Raycast(origin, angleVertex, viewDist);
            if (hit.collider == null)
            {
                vertex = origin + (angleVertex * viewDist);
            }
            else if (hit.collider.tag == PlayerTag)
            {
                GameOverPlayer();
                vertex = hit.point;
            }
            else
            {
                vertex = hit.point;
            }

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

        myMesh.vertices = vertices;
        myMesh.uv = uv;
        myMesh.triangles = triangles;

        myMesh.RecalculateBounds();
    }
    private void GameOverPlayer()
    {
        if(!doOnce)
        {
            Debug.Log("Player Spotted, Game Over");
        }
    }
    private Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}