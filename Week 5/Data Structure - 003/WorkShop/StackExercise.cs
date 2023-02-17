using UnityEngine;
using System.Collections.Generic;

public class StackExercise : MonoBehaviour
{
    private Stack<string> history = new Stack<string>();

    void Start()
    {
        history.Push("Page 1");
        history.Push("Page 2");
        history.Push("Page 3");

        while (history.Count > 0)
        {
            string page = history.Pop();
            Debug.Log(page);
        }
    }
}
/*
In this code, the history field is defined as a private Stack of strings and is initialized with an empty stack. 
The values are added to the stack in the Start() method, and the while loop pops and prints each value in reverse order.
Note that the Pop() method removes and returns the top element of the stack, so the while loop will continue until the stack is empty.
*/