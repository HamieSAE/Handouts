using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // The prefab of the bullet that will be used to create bullets for the pool
    public GameObject bulletPrefab;
    // The number of bullets to create in the pool
    public int numBullets;
    // A list of all the bullets in the pool
    private List<GameObject> bullets;

    // Called before the first frame update
    private void Awake()
    {
        // Create a new list to hold the bullets in the pool
        bullets = new List<GameObject>();
        // Create the specified number of bullets and add them to the pool
        for (int i = 0; i < numBullets; i++)
        {
            // Instantiate a new bullet using the bullet prefab and set it to inactive
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            // Add the bullet to the pool
            bullets.Add(bullet);
        }
    }

    // Get a bullet from the pool
    public GameObject GetBullet()
    {
        // Loop through all the bullets in the pool
        foreach (GameObject bullet in bullets)
        {
            // If the bullet is not active in the hierarchy, it is available to use
            if (!bullet.activeInHierarchy)
            {
                // Return the available bullet
                return bullet;
            }
        }
        // If there are no available bullets in the pool, return null
        return null;
    }
}
/*
This code creates an object pool for bullets in a game. When a bullet is needed, the game can call the GetBullet() method to get an available bullet from the pool. 
If there are no available bullets, the method returns null. The Awake() method is called when the object is created, and it creates a number of bullet instances and adds them to the pool. 
The bulletPrefab is used to create new bullets for the pool, and numBullets specifies the number of bullets to create.
*/
/*
This code creates an object pool for bullets in a game. When a bullet is needed, the game can call the GetBullet() method to get an available bullet from the pool. 
If there are no available bullets, the method returns null. 
The Awake() method is called when the object is created, and it creates a number of bullet instances and adds them to the pool. 
The bulletPrefab is used to create new bullets for the pool, and numBullets specifies the number of bullets to create.
*/