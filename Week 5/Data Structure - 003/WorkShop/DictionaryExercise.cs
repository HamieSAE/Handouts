using UnityEngine;
using System.Collections.Generic;

public class DictionaryExercise : MonoBehaviour
{
    // Define and initialize a new Dictionary that maps strings to integers at the class level
    Dictionary<string, int> ages = new Dictionary<string, int>()
    {
        {"John", 25},
        {"Mary", 30},
        {"Bob", 35}
    };

    void Start()
    {
        // Retrieve the value for a particular key using the index operator
        int maryAge = ages["Mary"];

        Debug.Log("Mary's age is " + maryAge);

        // Use a foreach loop to iterate over the dictionary and print each key-value pair to the console
        foreach (KeyValuePair<string, int> entry in ages)
        {
            Debug.Log(entry.Key + " is " + entry.Value + " years old.");
        }
    }
}
/*
This script defines and initializes the Dictionary at the class level, so it can be used in other methods or throughout the entire lifetime of the script.

The rest of the code remains the same. The script retrieves the value for a particular key ("Mary") using the index operator and prints a message to the console indicating Mary's age, 
    and uses a foreach loop to iterate over the dictionary and print each key-value pair to the console.
*/