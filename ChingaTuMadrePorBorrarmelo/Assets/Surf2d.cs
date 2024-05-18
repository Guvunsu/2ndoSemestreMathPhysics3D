using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surf2d : MonoBehaviour
{
    public int meshPoints;
    public Vector2 rangeX;
    public Vector2 rangeZ;
    public Material[] material;

    private float Lx, Lz;

    private Mesh mesh0, mesh1;
    private Vector3[] vertices;
    private int[] triangles;

    private List<GameObject> side;

    float time;
    public List<float> A = new List<float>();
    public List<Vector2> k = new List<Vector2>();
    public List<float> w = new List<float>();
    public List<float> phi = new List<float>();

    void Start()
    {
        InitSidesProperties();
        CreateMesh();
    }

    void Update()
    {
        time += Time.deltaTime;
        CreateMesh();
    }
    void FixedUpdate()
    {

        //CreateMesh();
    }

    float Function2D(float x, float z)
    {
        //float result = 0.25f * x * x + 0.25f * z * z;
        //float result = 0.25f * Mathf.Sin(x + z * 3 + time); // le agregue el 0.25f , el 3* y antes de esos cambios hubo uno que solamente estaba el mas time
        float result = WaveMotion2D.SumWave(A, k, w, phi, time, x, z);
        return result;

    }

    // No mires el código :u
    void CreateMesh()
    {
        vertices = new Vector3[(meshPoints + 1) * (meshPoints + 1)];

        int n = 0;
        float deltaX = Lx / (float)meshPoints;
        float deltaZ = Lz / (float)meshPoints;
        for (int j = 0; j <= meshPoints; j++)
        {
            for (int i = 0; i <= meshPoints; i++)
            {
                float x = i * deltaX + rangeX.x;
                float z = j * deltaZ + rangeZ.x;

                Vector3 vertex = new Vector3(x, Function2D(x, z), z);

                vertices[n] = vertex;
                n++;
            }
        }

        triangles = new int[meshPoints * meshPoints * 6];
        int vert = 0;
        int tris = 0;
        for (int j = 0; j < meshPoints; j++)
        {
            for (int i = 0; i < meshPoints; i++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + meshPoints + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + meshPoints + 1;
                triangles[tris + 5] = vert + meshPoints + 2;
                vert++;
                tris += 6;
            }
            vert++;
        }

        mesh0.Clear();
        mesh0.vertices = vertices;
        mesh0.triangles = triangles;
        mesh0.RecalculateNormals();
        mesh0.RecalculateTangents();

        System.Array.Reverse(triangles);
        Vector3[] invertedNormals = new Vector3[mesh0.normals.Length];
        Vector4[] tangents = mesh0.tangents;
        Vector4[] invertedTangents = new Vector4[tangents.Length];
        for (int i = 0; i < invertedNormals.Length; i++)
        {
            invertedNormals[i] = -mesh0.normals[i];
            invertedTangents[i] = tangents[i];
            invertedTangents[i].w = -invertedTangents[i].w;
        }

        mesh1.Clear();
        mesh1.vertices = vertices;
        mesh1.triangles = triangles;
        mesh1.normals = invertedNormals;
        mesh1.tangents = invertedTangents;
    }

    private void InitSidesProperties()
    {
        side = new List<GameObject>();

        side.Add(transform.GetChild(0).gameObject);
        side.Add(transform.GetChild(1).gameObject);

        side[0].AddComponent<MeshFilter>();
        side[1].AddComponent<MeshFilter>();

        side[0].AddComponent<MeshRenderer>();
        side[1].AddComponent<MeshRenderer>();

        side[0].GetComponent<MeshRenderer>().material = material[0];
        side[1].GetComponent<MeshRenderer>().material = material[1];

        mesh0 = new Mesh();
        mesh1 = new Mesh();

        side[0].GetComponent<MeshFilter>().mesh = mesh0;
        side[1].GetComponent<MeshFilter>().mesh = mesh1;
        Lx = rangeX.y - rangeX.x;
        Lz = rangeZ.y - rangeZ.x;
    }
}
