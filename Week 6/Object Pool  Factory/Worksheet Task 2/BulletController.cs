using UnityEngine;

public class BulletController : MonoBehaviour
{
    // The speed at which the bullet moves
    public float speed;

    // Move the bullet forward
    public void Fire()
    {
        // Set the bullet to active
        gameObject.SetActive(true);

        // Move the bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
/*
It defines a Fire method that moves the bullet forward and sets it to active when called. The speed at which the bullet moves can be set in the inspector.
*/