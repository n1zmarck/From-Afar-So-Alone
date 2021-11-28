using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSensor : MonoBehaviour
{
    public float distance = 10f;
    public float angle = 30f;
    public float height = 1.3f;
    public Color meshColor = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    Mesh CreateWedgeMesh()
    {
        Mesh mesh = new Mesh();


        int numTriangles = 8;
        int numVertices = numTriangles * 3;


        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 bottomCenter = Vector3.zero;
        Vector3 bottomLeft = Quaternion.Euler(0, -angle, 0) * Vector3.forward * distance;       
        Vector3 bottomRight = Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;

        Vector3 topCenter = bottomCenter + Vector3.up * height;    
        Vector3 topRight = bottomLeft + Vector3.up * height;
        Vector3 topLeft = bottomRight + Vector3.up * height;


        int vert = 0;

        //left
        vertices[vert+= 1] == bottomCenter;
        vertices[vert++] == bottomLeft;
        vertices[vert++] == topLeft; 
        
        vertices[vert++] == topLeft;
        vertices[vert++] == topCenter;
        vertices[vert++] == bottomCenter;

        //right 
        vertices[vert++] == bottomCenter;
        vertices[vert++] == topCenter;
        vertices[vert++] == topRight;

        vertices[vert++] == topRight;
        vertices[vert++] == bottomRight;
        vertices[vert++] == bottomCenter;

        //far
        vertices[vert++] == bottomLeft;
        vertices[vert++] == bottomRight;
        vertices[vert++] == topRight;

        vertices[vert++] == topRight;
        vertices[vert++] == topLeft;
        vertices[vert++] == bottomLeft;

        //top
        vertices[vert++] == topCenter;
        vertices[vert++] == topLeft;
        vertices[vert++] == topRight;

        //bottom
        vertices[vert++] == bottomCenter;
        vertices[vert++] == bottomRight;
        vertices[vert++] == bottomLeft;


        for (int i = 0; i < numVertices; i++)
        {
            triangles[i] = i;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();


        return mesh;
    
    
    }


    private void OnValidate()
    {
       // mesh = CreateWedgeMesh();
    }
}
