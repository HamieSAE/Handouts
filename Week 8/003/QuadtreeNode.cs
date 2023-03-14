using System.Collections.Generic;
using UnityEngine;

public class QuadtreeNode
{
    public Rect bounds; // The boundary of this quadtree node
    public List<GameObject> objects; // The list of game objects in this node
    public QuadtreeNode[] children; // The 4 child nodes of this node

    public QuadtreeNode(Rect bounds)
    {
        this.bounds = bounds;
        this.objects = new List<GameObject>();
        this.children = null;
    }

    // Splits the current node into 4 child nodes
    public void Split()
    {
        float subWidth = bounds.width / 2f;
        float subHeight = bounds.height / 2f;
        float x = bounds.x;
        float y = bounds.y;

        children = new QuadtreeNode[4];
        children[0] = new QuadtreeNode(new Rect(x + subWidth, y, subWidth, subHeight));
        children[1] = new QuadtreeNode(new Rect(x, y, subWidth, subHeight));
        children[2] = new QuadtreeNode(new Rect(x, y + subHeight, subWidth, subHeight));
        children[3] = new QuadtreeNode(new Rect(x + subWidth, y + subHeight, subWidth, subHeight));
    }

    // Returns the index of the child node that the game object belongs to
    public int GetChildIndex(GameObject obj)
    {
        int index = -1;

        if (children != null)
        {
            for (int i = 0; i < children.Length; i++)
            {
                if (children[i].bounds.Contains(obj.transform.position))
                {
                    index = i;
                    break;
                }
            }
        }

        return index;
    }

    // Inserts the game object into the appropriate node
    public void Insert(GameObject obj)
    {
        if (!bounds.Contains(obj.transform.position))
        {
            return;
        }

        if (children != null)
        {
            int childIndex = GetChildIndex(obj);
            if (childIndex != -1)
            {
                children[childIndex].Insert(obj);
                return;
            }
        }

        objects.Add(obj);

        // If the number of objects in this node exceeds the maximum limit and there are no child nodes, split this node
        if (objects.Count > Quadtree.MAX_OBJECTS_PER_NODE && children == null)
        {
            Split();

            // Move each object to the appropriate child node
            for (int i = 0; i < objects.Count; i++)
            {
                int childIndex = GetChildIndex(objects[i]);
                if (childIndex != -1)
                {
                    children[childIndex].Insert(objects[i]);
                    objects.RemoveAt(i);
                    i--;
                }
            }
        }
    }

    // Retrieves all objects in the given area
    public List<GameObject> Retrieve(Rect area)
    {
        List<GameObject> retrievedObjects = new List<GameObject>();

        // If the given area does not intersect with this node's bounds, return an empty list
        if (!bounds.Intersects(area))
        {
            return retrievedObjects;
        }

        // If this node has child nodes, retrieve objects from them
        if (children != null)
        {
            for (int i = 0; i < children.Length; i++)
            {
                retrievedObjects.AddRange(children[i].Retrieve(area));
            }
        }

        // Add objects in this node to the list if they are within the given area
        for (int i = 0; i < objects.Count; i++)
        {
            if (area.Contains(objects[i].transform.position))
            {
                retrievedObjects.Add(objects[i]);
            }
        }

        return retrievedObjects;
    }
}
/*
This is a class definition for a Quadtree node, used in spatial partitioning to efficiently query objects in a 2D space. The class contains the following:

bounds: a Rect object defining the bounds of the node.
objects: a list of GameObject objects that are contained within the node.
children: an array of four QuadtreeNode objects that represent the four quadrants of the node. This is used to recursively partition the space.
QuadtreeNode(Rect bounds): a constructor that takes a Rect object defining the bounds of the node and initializes the objects list and children array.
Split(): a method that splits the node into four children nodes, representing the four quadrants of the node.
GetChildIndex(GameObject obj): a method that returns the index of the child node that the given GameObject object belongs to. Returns -1 if the object does not belong to any of the children nodes.
Insert(GameObject obj): a method that inserts a GameObject object into the node. If the node has more than a certain number of objects (Quadtree.MAX_OBJECTS_PER_NODE) and has not been split yet, the node is split and the objects are distributed among the children nodes.
Retrieve(Rect area): a method that returns a list of GameObject objects that intersect with the given Rect area. This method recursively queries the children nodes and their objects.
*/