using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // A list to hold references to the bullet GameObjects in the pool
    public List<GameObject> bullets;

    // The number of bullets to create in the pool
    public int numBullets;

    private void Awake()
    {
        // Instantiate and disable each bullet GameObject and add it to the pool list
        bullets = new List<GameObject>();
        for (int i = 0; i < numBullets; i++)
        {
            // Instantiate the bullet GameObject from the "Bullet" resource with position and rotation at Vector3.zero and Quaternion.identity
            GameObject obj = Instantiate(Resources.Load("Bullet"), Vector3.zero, Quaternion.identity) as GameObject;
            obj.SetActive(false); // Set the bullet GameObject as inactive
            bullets.Add(obj); // Add the bullet GameObject to the pool list
        }
    }

    // Get a bullet GameObject from the pool
    public GameObject GetBullet()
    {
        // Check each bullet GameObject in the pool
        foreach (GameObject obj in bullets)
        {
            // If the bullet GameObject is not active in the scene
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true); // Set the bullet GameObject as active
                return obj; // Return the bullet GameObject
            }
        }
        // If no inactive bullet GameObjects are found in the pool
        // Instantiate a new bullet GameObject from the "Bullet" resource, set it as active, and add it to the pool list
        GameObject newObj = Instantiate(Resources.Load("Bullet"), Vector3.zero, Quaternion.identity) as GameObject;
        newObj.SetActive(true);
        bullets.Add(newObj);
        return newObj; // Return the new bullet GameObject
    }

    // Return a bullet GameObject to the pool
    public void ReturnBullet(GameObject obj)
    {
        obj.SetActive(false); // Set the bullet GameObject as inactive
    }
}
/*
This script is an implementation of an object pool, which is a commonly used design pattern in game development to efficiently manage and reuse objects (in this case, bullets). 
When the game starts, it creates a number of bullet GameObjects (specified by numBullets) and adds them to a list (bullets) in an inactive state. 
When a bullet is needed in the game, it can be retrieved from the object pool using GetBullet(), which checks the list for an inactive bullet and returns it if found. 
If no inactive bullet is found, a new one is instantiated and added to the list. 
When a bullet is no longer needed, it can be returned to the object pool using ReturnBullet(), which sets it as inactive. 
This way, the game doesn't have to constantly create and destroy bullets, which can be resource-intensive, and can instead efficiently reuse them from the object pool.
*/