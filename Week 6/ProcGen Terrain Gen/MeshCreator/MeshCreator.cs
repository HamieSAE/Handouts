using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshCreator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    void Start()
    {
        // Create a new Mesh object and assign it to the MeshFilter component
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // Create the initial shape of the mesh
        CreateShape();

        // Update the mesh with the initial shape
        UpdateMesh();
    }

    void CreateShape()
    {
        // Define the vertices that make up the shape of the mesh
        vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(1, 0, 0)
        };

        // Define the triangles that connect the vertices to create the faces of the mesh
        triangles = new int[]
        {
            0, 1, 2
        };
    }

    void UpdateMesh()
    {
        // Clear the existing mesh
        mesh.Clear();
        // Update the vertices and triangles of the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        // Recalculate the normals of the mesh for correct lighting
        mesh.RecalculateNormals();
    }
}
/*
This code creates a simple mesh using Unity's Mesh class. 
The mesh consists of a single triangle with three vertices located at the corners of a 1x1 square on the XZ plane. 
The CreateShape() method initializes the vertices and triangles arrays, and the UpdateMesh() method sets these arrays as the vertices and triangles of the mesh, respectively. 
The Start() method creates a new Mesh object and assigns it to the MeshFilter component of the game object, and then calls CreateShape() and UpdateMesh() to create and display the mesh.
*/