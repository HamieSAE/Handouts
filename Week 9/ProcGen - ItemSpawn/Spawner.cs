// Import the necessary libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Declare a new class named "Spawner", which inherits from MonoBehaviour
public class Spawner : MonoBehaviour
{
    // Declare public variables for the object to spawn and number of times to spawn it
    public GameObject itemToSpawn;
    public int numSpawns = 1;

    // Declare public variables for the random spawning position of the object
    public int itemX = 2;
    public int itemY = 0;
    public int itemZ = 4;

    // Start is called before the first frame update
    void Start()
    {
        // For loop to spawn the object "numSpawns" times
        for (int i = 0; i < numSpawns; i++)
        {
            SpawnItem();
        }
    }

    // SpawnItem method to create a new object clone at a random position within the declared range
    void SpawnItem()
    {
        // Define a new vector representing the random spawn position
        Vector3 randomPos = new Vector3(Random.Range(-itemX, itemX),Random.Range(-itemY, itemY),Random.Range(-itemZ, itemZ));

        // Create a new clone of the itemToSpawn GameObject at the random position with no rotation
        GameObject clone = Instantiate(itemToSpawn, randomPos, Quaternion.identity);
    }
}
