using UnityEngine;
using System.Collections.Generic;

public class ListExercise : MonoBehaviour
{
    void Start()
    {
        // Define and initialize a new list of integers
        List<int> numbers = new List<int>();

        // Add some numbers to the list using the Add() method
        numbers.Add(10);
        numbers.Add(20);
        numbers.Add(30);

        // Use a foreach loop to iterate over the list and print each element to the console
        foreach (int number in numbers)
        {
            Debug.Log(number);
        }
    }
}
/*
This script first defines and initializes a new list of integers called numbers. 
It then adds some numbers to the list using the Add() method.
Next, the script uses a foreach loop to iterate over the list and print each element to the console using the Debug.Log() method. 
The foreach loop iterates over each element in the numbers list and assigns it to the number variable, which is then printed to the console.
*/