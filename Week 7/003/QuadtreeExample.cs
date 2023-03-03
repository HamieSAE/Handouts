using System.Collections.Generic;
using UnityEngine;

public class QuadtreeExample : MonoBehaviour
{
    public GameObject prefab; // The GameObject prefab that will be instantiated
    public int numObjects = 100; // The number of GameObjects to instantiate
    public int maxDepth = 5; // The maximum depth of the Quadtree

    private Quadtree quadtree; // The Quadtree instance
    private List<GameObject> objects; // The list of all the instantiated GameObjects

    private void Start()
    {
        objects = new List<GameObject>(); // Initialize the list of GameObjects

        // Instantiate numObjects GameObjects with random positions
        for (int i = 0; i < numObjects; i++)
        {
            Vector2 position = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            GameObject obj = Instantiate(prefab, position, Quaternion.identity);
            obj.name = "Object " + i; // Name the object for debugging purposes
            objects.Add(obj); // Add the object to the list
        }

        // Create a new Quadtree instance with a Rect bounds and maximum depth
        quadtree = new Quadtree(new Rect(-10f, -10f, 20f, 20f), maxDepth);

        // Insert all the GameObjects into the Quadtree
        for (int i = 0; i < objects.Count; i++)
        {
            quadtree.Insert(objects[i]);
        }
    }

    private void Update()
    {
        // Create a Rect area centered around the mouse position
        Rect area = new Rect(Input.mousePosition.x, Input.mousePosition.y, 5f, 5f);

        // Retrieve all the GameObjects within the area
        List<GameObject> retrievedObjects = quadtree.Retrieve(area);

        // Reset the color of all the GameObjects
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].GetComponent<Renderer>().material.color = Color.white;
        }

        // Set the color of the retrieved GameObjects to green
        for (int i = 0; i < retrievedObjects.Count; i++)
        {
            retrievedObjects[i].GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
/*
This code is an example implementation of the Quadtree data structure in Unity. 
It creates a number of GameObjects with random positions, inserts them into a Quadtree, and allows the user to retrieve all the GameObjects within a certain area by moving the mouse. 
The retrieved GameObjects are then highlighted in green while the rest remain white. 
This is a simple example of how Quadtree can be used for efficient collision detection or object culling in games.
*/