using UnityEngine;

public class ExampleScriptPart3 : MonoBehaviour // declare the ExampleScript class and inherit from the MonoBehaviour class
{
    public Transform playerTransform; // a public field for the Transform of the player
    public Transform gameObjectTransform; // a public field for the Transform of the game object
    public float checkpoint1Distance = 10f; // a public field for the distance of checkpoint 1
    public float checkpoint2Distance = 5f; // a public field for the distance of checkpoint 2
    public float checkpoint3Distance = 1f; // a public field for the distance of checkpoint 3
    public MeshRenderer gameobjectRenderer; // a public field for the MeshRenderer of the game object

    private bool passedCheckpoint1 = false; // a private field to track if checkpoint 1 has been passed
    private bool passedCheckpoint2 = false; // a private field to track if checkpoint 2 has been passed
    private bool passedCheckpoint3 = false; // a private field to track if checkpoint 3 has been passed

    private void Update() // method called once per frame
    {
        float distance = Vector3.Distance(playerTransform.position, gameObjectTransform.position); // calculate the distance between the player and the game object

        if (distance <= checkpoint1Distance && !passedCheckpoint1) // if the player is within checkpoint 1 distance and has not yet passed checkpoint 1
        {
            passedCheckpoint1 = true; // set passedCheckpoint1 to true
            gameobjectRenderer.material = Resources.Load<Material>("Cylinder Material"); // change the game object's material to the cylinder material
            Debug.Log("Player has passed checkpoint 1."); // log a message indicating that checkpoint 1 has been passed
        }

        if (distance <= checkpoint2Distance && !passedCheckpoint2) // if the player is within checkpoint 2 distance and has not yet passed checkpoint 2
        {
            passedCheckpoint2 = true; // set passedCheckpoint2 to true
            gameobjectRenderer.material = Resources.Load<Material>("Capsule Material"); // change the game object's material to the capsule material
            Debug.Log("Player has passed checkpoint 2."); // log a message indicating that checkpoint 2 has been passed
        }

        if (distance <= checkpoint3Distance && !passedCheckpoint3) // if the player is within checkpoint 3 distance and has not yet passed checkpoint 3
        {
            passedCheckpoint3 = true; // set passedCheckpoint3 to true
            gameobjectRenderer.material = Resources.Load<Material>("Box Material"); // change the game object's material to the box material
            Debug.Log("Player has passed checkpoint 3."); // log a message indicating that checkpoint 3 has been passed
        }
    }
}
/*
This script has a few purposes. It allows you to assign the player's transform and the game object's transform in the inspector, as well as set distances for three checkpoints.
In the Update method, the script calculates the distance between the player and the game object using Vector3.Distance. 
It then checks if the distance is less than the checkpoint distances, and if so, it sets a boolean variable for that checkpoint to true and changes the material of the game object's mesh renderer to a different material for that checkpoint. 
It also logs a message to the console indicating which checkpoint was passed.
*/