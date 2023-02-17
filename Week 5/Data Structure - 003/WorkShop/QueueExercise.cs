using UnityEngine;
using System.Collections.Generic;

public class QueueExercise : MonoBehaviour
{
    void Start()
    {
        // Define a new Queue of strings
        Queue<string> actions = new Queue<string>();

        // Add some actions to the queue using the Enqueue() method
        actions.Enqueue("Jump");
        actions.Enqueue("Shoot");
        actions.Enqueue("Dodge");

        // Use a while loop to dequeue and print each action in order
        while (actions.Count > 0)
        {
            string action = actions.Dequeue();
            Debug.Log(action);
        }
    }
}
/*
This script defines a Queue of strings, adds some actions to the queue using the Enqueue() method, and then dequeues and prints each action in order using a while loop. 
The loop runs as long as the queue has items (i.e. its Count is greater than 0). 
In each iteration, the script dequeues the first item in the queue using the Dequeue() method, assigns it to a string variable, and prints it to the console using Debug.Log().
*/