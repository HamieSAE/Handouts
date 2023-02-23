using System.Collections.Generic; // Import the List data structure
using UnityEngine; // Import the Unity engine

public class ObjectPool : MonoBehaviour // Define the ObjectPool class
{
    public GameObject platformPrefab; // The prefab for the platform object
    public int numPlatforms; // The number of platforms to create in the pool
    private List<GameObject> platforms; // The list of platform objects in the pool

    private void Awake() // Called when the script is first loaded
    {
        platforms = new List<GameObject>(); // Initialize the list of platform objects
        for (int i = 0; i < numPlatforms; i++) // Loop over the number of platforms to create
        {
            GameObject platform = Instantiate(platformPrefab); // Create a new platform object from the prefab
            platform.SetActive(false); // Deactivate the platform object
            platforms.Add(platform); // Add the platform object to the list of platforms
        }
    }

    public GameObject GetPlatform() // Get an inactive platform object from the pool
    {
        foreach (GameObject platform in platforms) // Loop over the list of platform objects
        {
            if (!platform.activeInHierarchy) // If the platform object is not active in the scene
            {
                return platform; // Return the platform object
            }
        }
        return null; // If no inactive platform objects were found, return null
    }

    public void ReturnPlatform(GameObject platform) // Return a platform object to the pool
    {
        platform.SetActive(false); // Deactivate the platform object
        platform.transform.position = transform.position; // Reset the platform object's position to the object pool's position
    }
}
/*
This script defines an object pool for platform objects. When the script is loaded, it creates a number of platform objects and deactivates them. These deactivated platform objects are stored in a list.
The GetPlatform method returns an inactive platform object from the pool, if one is available. It loops over the list of platform objects in the pool and returns the first inactive platform object it finds.
The ReturnPlatform method takes a platform object and returns it to the pool. It deactivates the platform object and resets its position to the position of the object pool.
*/