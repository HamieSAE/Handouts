using UnityEngine;
using System.Collections.Generic;

public class HashSetExercise : MonoBehaviour
{
    // Define and initialize a new HashSet of strings at the class level
    HashSet<string> words = new HashSet<string>() {"apple", "banana", "orange"};

    void Start()
    {
        // Check if the HashSet contains a particular word using the Contains() method
        if (words.Contains("banana"))
        {
            Debug.Log("Found banana!");
        }

        // Use a foreach loop to iterate over the HashSet and print each element to the console
        foreach (string word in words)
        {
            Debug.Log(word);
        }
    }
}
/*
This script defines and initializes the HashSet at the class level, so it can be used in other methods or throughout the entire lifetime of the script.
The rest of the code remains the same. The script checks if the HashSet contains a particular word ("banana") and prints a message to the console if it does,
     and uses a foreach loop to iterate over the HashSet and print each element to the console.
*/