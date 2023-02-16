using System.Collections.Generic;
using UnityEngine;

public class StackExample : MonoBehaviour
{
    void Start()
    {
        Stack<string> history = new Stack<string>();
        history.Push("Page 1");
        history.Push("Page 2");
        history.Push("Page 3");

        while (history.Count > 0)
        {
            string page = history.Pop();
            Debug.Log("Viewing page: " + page);
        }
    }
}
/*This script creates a Stack of strings that contains three pages, adds them to the Stack, 
and then uses a while loop to view and print out each page in reverse order (i.e., the last page added is viewed first).*/