using System.Collections.Generic;
using UnityEngine;

public class QueueExample : MonoBehaviour
{
    void Start()
    {
        Queue<string> actions = new Queue<string>();
        actions.Enqueue("Jump");
        actions.Enqueue("Shoot");
        actions.Enqueue("Dodge");

        while (actions.Count > 0)
        {
            string action = actions.Dequeue();
            Debug.Log("Performing action: " + action);
        }
    }
}
//This script creates a Queue of strings that contains three actions, adds them to the Queue, and then uses a while loop to perform and print out each action in order.