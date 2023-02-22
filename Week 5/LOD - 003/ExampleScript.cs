using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    public Transform playerTransform; // A public Transform variable to hold a reference to the player's transform.
    public Transform gameObjectTransform; // A public Transform variable to hold a reference to the game object's transform.

    private void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, gameObjectTransform.position); // Calculates the distance between the player and the game object.
        Debug.Log("Distance between player and game object: " + distance); // Outputs the distance to the console.
    }
}
/*
This script creates a custom component called ExampleScript. It has two public Transform variables: playerTransform and gameObjectTransform. 
These are used to hold references to the transforms of the player and the game object that this script is attached to.
In the Update method, the distance between the player and the game object is calculated using Vector3.Distance() and assigned to a local variable distance. 
The Debug.Log() method is then used to output the distance to the console.
This script is designed to be attached to a game object that needs to track the distance between itself and the player. It does not affect the behavior of the game object in any other way.
*/