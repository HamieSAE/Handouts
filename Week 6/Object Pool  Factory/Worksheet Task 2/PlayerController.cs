using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // The key to press to fire a bullet
    public KeyCode fireKey = KeyCode.Space;
    // Reference to the object pool
    public ObjectPool objectPool;

    // Update is called once per frame
    private void Update()
    {
        // If the fire key is pressed, fire a bullet
        if (Input.GetKeyDown(fireKey))
        {
            // Get an inactive bullet from the object pool
            GameObject bullet = objectPool.GetBullet();
            // If a bullet was obtained from the pool, fire it
            if (bullet != null)
            {
                // Call the Fire method on the bullet's BulletController component
                bullet.GetComponent<BulletController>().Fire();
            }
        }
    }
}
/*
This script is a PlayerController class that listens for a key press to fire a bullet. 
It has a public fireKey property that specifies which key to press to fire the bullet, and a public ObjectPool objectPool property that references the object pool that will be used to obtain bullets.
In the Update() method, it checks if the fire key has been pressed by calling Input.GetKeyDown(fireKey). 
If the key has been pressed, it calls objectPool.GetBullet() to obtain an inactive bullet from the object pool. 
If a bullet was obtained from the pool (i.e. it wasn't null), it calls the Fire() method on the BulletController component attached to the bullet game object, which sets the bullet to active and moves it forward.
*/