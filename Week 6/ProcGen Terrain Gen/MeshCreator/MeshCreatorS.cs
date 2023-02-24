using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Require the MeshFilter component to be attached to this game object
[RequireComponent(typeof(MeshFilter))]
public class MeshCreatorS : MonoBehaviour
{
    // The Mesh that will be created
    Mesh mesh;

    // An array of vertices that define the shape of the mesh
    Vector3[] vertices;

    // An array of integers that define the triangles of the mesh
    int[] triangles;

    void Start()
    {
        // Create a new Mesh object and set it as the MeshFilter's mesh
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // Create the shape of the mesh by setting its vertices and triangles
        CreatShape();

        // Update the mesh with the newly created vertices and triangles
        UpdateMesh();
    }

    // Defines the shape of the mesh by setting its vertices and triangles
    void CreatShape()
    {
        // Set the vertices of the mesh
        vertices = new Vector3[] 
        {
            new Vector3 (0,0,0),
            new Vector3 (0,0,1),
            new Vector3 (1,0,0),
            new Vector3 (1,0,1)
        };

        // Set the triangles of the mesh
        triangles = new int[]
        {
            0, 1, 2,
            1, 3, 2
        };
    }

    // Updates the mesh with the newly created vertices and triangles
    void UpdateMesh()
    {
        // Clear the existing mesh
        mesh.Clear();

        // Set the vertices and triangles of the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // Recalculate the normals of the mesh
        mesh.RecalculateNormals();
    }
}
/*
This script creates a simple mesh with a square shape made up of two triangles. 
It does this by defining an array of vertices that determine the shape of the mesh, and an array of integers that define the triangles of the mesh. 
The CreatShape() method sets these arrays to create the shape of the mesh. 
The UpdateMesh() method sets the vertices and triangles of the Mesh object, and recalculates the normals of the mesh. 
The Start() method creates a new Mesh object and sets it as the mesh of the MeshFilter component attached to the game object. 
It then creates the shape of the mesh and updates it.
*/