using System.Collections.Generic;
using UnityEngine;

public class Quadtree
{
    public const int MAX_OBJECTS_PER_NODE = 2; // A constant variable that represents the maximum number of objects a QuadtreeNode can hold.

    public QuadtreeNode root; // The root node of the quadtree.
    public int maxDepth; // The maximum depth the quadtree can go to.

    public Quadtree(Rect bounds, int maxDepth) // Constructor that initializes the quadtree with a rectangular boundary and a maximum depth.
    {
        this.root = new QuadtreeNode(bounds); // Create the root node with the specified boundary.
        this.maxDepth = maxDepth; // Set the maximum depth of the quadtree.
    }

    public void Insert(GameObject obj) // Insert a game object into the quadtree.
    {
        root.Insert(obj); // Insert the game object into the root node.
    }

    public List<GameObject> Retrieve(Rect area) // Retrieve all game objects that are within the specified rectangular area.
    {
        return root.Retrieve(area); // Call the retrieve method of the root node to get all game objects within the area.
    }
}
/*
In summary, this code defines a Quadtree class that is used to store and retrieve game objects based on their position in a two-dimensional space. 
The class uses a quadtree data structure, which recursively divides the space into four quadrants and stores game objects in nodes based on their position in the space. 
The quadtree allows for efficient retrieval of game objects that are within a specified rectangular area.
*/