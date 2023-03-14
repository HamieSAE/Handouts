using System.Collections.Generic;
using UnityEngine;

public class OctreeExample : MonoBehaviour
{
    // Public variables
    public GameObject prefab;
    public int numObjects = 100;
    public int maxDepth = 5;

    // Private variables
    private Octree octree;
    private List<GameObject> objects;

    // Start is called before the first frame update
    void Start()
    {
        // Create an empty list to store game objects
        objects = new List<GameObject>();

        // Spawn game objects
        for (int i = 0; i < numObjects; i++)
        {
            // Generate a random position within a cube with a side length of 20 units
            Vector3 position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));

            // Instantiate the game object and add it to the list
            GameObject obj = Instantiate(prefab, position, Quaternion.identity);
            obj.name = "Object " + i;
            objects.Add(obj);
        }

        // Create the octree
        octree = new Octree(new Bounds(Vector3.zero, new Vector3(20f, 20f, 20f)), maxDepth);

        // Insert each game object into the octree
        for (int i = 0; i < objects.Count; i++)
        {
            octree.Insert(objects[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Retrieve game objects within a range around the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float range = 2f;
        Bounds area = new Bounds(mousePos, new Vector3(range, range, range));
        List<GameObject> retrievedObjects = octree.Retrieve(area);

        // Set the color of retrieved game objects to red
        for (int i = 0; i < retrievedObjects.Count; i++)
        {
            retrievedObjects[i].GetComponent<Renderer>().material.color = Color.red;
        }

        // Set the color of non-retrieved game objects to white
        for (int i = 0; i < objects.Count; i++)
        {
            if (!retrievedObjects.Contains(objects[i]))
            {
                objects[i].GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}
/*This script creates a random set of objects in a cube, and inserts them into an Octree data structure. 
It then retrieves all the objects within a certain range around the mouse position every frame and highlights them in red, while setting the non-retrieved objects to white. 
This demonstrates how an Octree can be used for efficient range queries in 3D space.
*/