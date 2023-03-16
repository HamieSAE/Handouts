using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Declare an array of GameObjects to spawn from
    public GameObject[] spawnItems;

    // Declare public variables for the number of times to spawn items, as well as the range of random spawn positions
    public int numSpawns = 1;
    public int itemX = 2;
    public int itemY = 0;
    public int itemZ = 4;

    void Start()
    {
        // For loop to spawn the object "numSpawns" times
        for (int i = 0; i < numSpawns; i++)
        {
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        // Define a random index to select from the array of spawnItems
        int randomIndex = Random.Range(0, spawnItems.Length);

        // Define a new vector representing the random spawn position
        Vector3 randomPos = new Vector3(Random.Range(-itemX, itemX), Random.Range(-itemY, itemY), Random.Range(-itemZ, itemZ));

        // Create a new clone of the selected spawnItem at the random position with no rotation
        GameObject clone = Instantiate(spawnItems[randomIndex], randomPos, Quaternion.identity);
    }
}
/*
In this updated version, we declare an array of GameObjects spawnItems from which the items are randomly selected for spawning. 
The SpawnItem() method now first selects a random index from the spawnItems array, and then spawns the item corresponding to that index at a random position within the specified range.
Note that we've removed the itemToSpawn variable since it's no longer used. Instead, we're using the spawnItems array to randomly select the object to spawn.
*/