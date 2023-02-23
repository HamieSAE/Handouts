using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fireRate = 0.5f; // the rate at which the player can fire
    public GameObject bulletPrefab; // the bullet prefab

    private ObjectPool objectPool; // the object pool that stores bullets
    private float nextFire = 0.0f; // the time at which the player can fire again

    private void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>(); // find the object pool in the scene
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire) // if the player presses the fire button and the time has passed since the last fire
        {
            nextFire = Time.time + fireRate; // set the time at which the player can fire again
            GameObject bullet = objectPool.GetBullet(); // get a bullet from the object pool
            bullet.transform.position = transform.position + transform.forward * 2; // set the bullet's position
            bullet.transform.rotation = transform.rotation; // set the bullet's rotation
            bullet.SetActive(true); // activate the bullet
        }
    }
}
/*
This script is for the player controller and it allows the player to shoot bullets. 
It uses an object pool to optimize the creation and destruction of bullets. 
The fireRate variable determines how fast the player can shoot bullets. 
The bulletPrefab variable is the bullet prefab that will be spawned when the player shoots. 
In the Start method, it finds the ObjectPool script in the scene. 
In the Update method, it checks if the player presses the fire button and if the time has passed since the last fire. 
If it is true, then it gets a bullet from the object pool, sets its position and rotation to the player's position and rotation, and activates it.
*/