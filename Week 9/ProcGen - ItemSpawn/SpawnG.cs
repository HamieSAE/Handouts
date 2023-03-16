// Import the necessary libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Declare a new class named "Spawner", which inherits from MonoBehaviour
public class SpawnG : MonoBehaviour
{
    // Declare public variables for the object to spawn and number of times to spawn it
    public GameObject itemToSpawn;
    public int numSpawns = 1;
    // Declare public variables for the area in which to spawn objects
    public Vector3 centre;
    public Vector3 size;
    // Start is called before the first frame update
    void Start()
    {
        // For loop to spawn the object "numSpawns" times
        for (int i = 0; i < numSpawns; i++)
        {
            SpawnItem();
        }
    }
    // This method is called in the Unity Editor when the user selects the GameObject with this script attached and is used to draw a Gizmo in the scene view to represent the area in which objects will be spawned
    void OnDrawGizmosSelected() 
    {
        Gizmos.color = new Color(1,0,0,0.5f); // Set the color of the Gizmo to red with a 50% opacity
        Gizmos.DrawCube(centre, size); // Draw a cube with the dimensions of "size" centered at "centre" to represent the spawning area
    }
    // This method spawns a single object at a random position within the defined spawning area
    void SpawnItem()
    {
        // Calculate a random position within the specified area
        Vector3 posit = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2),Random.Range(-size.y / 2, size.y / 2),Random.Range(-size.z / 2, size.z / 2));
        // Instantiate the object at the random position with no rotation
        Instantiate(itemToSpawn, posit, Quaternion.identity);
    }
}

/*
void SpawnItem()
{
    // Calculate a random position within the specified area
    Vector3 position = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

    // Instantiate the object at the random position with no rotation
    GameObject spawnedObject = Instantiate(itemToSpawn, position, Quaternion.identity);

    // Add movement behavior to the spawned object
    Rigidbody rigidbody = spawnedObject.GetComponent<Rigidbody>();
    if (rigidbody != null)
    {
        // Set the velocity of the rigidbody to a random direction and speed
        float speed = 5f; // Change this value to adjust the speed of the movement
        rigidbody.velocity = Random.onUnitSphere * speed;
    }
}
*/