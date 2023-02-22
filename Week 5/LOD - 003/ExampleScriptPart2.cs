using UnityEngine;

public class ExampleScriptPart2 : MonoBehaviour
{
    // Declare public transforms and checkpoint distances
    public Transform playerTransform;
    public Transform gameObjectTransform;
    public float checkpoint1Distance = 10f;
    public float checkpoint2Distance = 5f;
    public float checkpoint3Distance = 1f;

    // Declare boolean variables to track whether the player has passed each checkpoint
    private bool passedCheckpoint1 = false;
    private bool passedCheckpoint2 = false;
    private bool passedCheckpoint3 = false;

    // Update is called once per frame
    private void Update()
    {
        // Calculate the distance between the player and the game object
        float distance = Vector3.Distance(playerTransform.position, gameObjectTransform.position);

        // Log the distance between the player and the game object
        Debug.Log("Distance to game object: " + distance);

        // Check if the player has passed checkpoint 1 and log the event if so
        if (distance <= checkpoint1Distance && !passedCheckpoint1)
        {
            passedCheckpoint1 = true;
            Debug.Log("Player has passed checkpoint 1.");
        }

        // Check if the player has passed checkpoint 2 and log the event if so
        if (distance <= checkpoint2Distance && !passedCheckpoint2)
        {
            passedCheckpoint2 = true;
            Debug.Log("Player has passed checkpoint 2.");
        }

        // Check if the player has passed checkpoint 3 and log the event if so
        if (distance <= checkpoint3Distance && !passedCheckpoint3)
        {
            passedCheckpoint3 = true;
            Debug.Log("Player has passed checkpoint 3.");
        }
    }
}
/*
This script is attached to a game object in a Unity scene and is used to track the player's progress as they move towards the game object. 
The script has a playerTransform and gameObjectTransform variable that are used to get the position of the player and the game object, respectively. 
There are also three checkpoint distances declared that define the distances at which the player passes checkpoints 1, 2, and 3.
The script uses three boolean variables, passedCheckpoint1, passedCheckpoint2, and passedCheckpoint3, to track whether the player has passed each checkpoint. 
These variables are initialized to false at the start of the script.
In the Update() method, the script calculates the distance between the player and the game object using Vector3.Distance(). It then logs the distance to the console using Debug.Log().
The script then checks if the player has passed each of the three checkpoints. 
If the player has passed a checkpoint, and that checkpoint has not already been passed, the script logs a message to the console indicating that the player has passed that checkpoint and sets the corresponding boolean variable to true. 
Once a checkpoint has been passed, it will not be logged again.
*/