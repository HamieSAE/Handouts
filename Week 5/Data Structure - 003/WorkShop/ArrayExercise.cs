using UnityEngine;
using System.Linq;

public class ArrayExercise : MonoBehaviour
{
    void Start()
    {
        // Define and initialize the first array
        int[] numbers = new int[5];
        numbers[0] = 10;
        numbers[1] = 20;
        numbers[2] = 30;
        numbers[3] = 40;
        numbers[4] = 50;

        // Use a for loop to iterate over the array and print each element to the console
        for (int i = 0; i < numbers.Length; i++)
        {
            Debug.Log("numbers[" + i + "] = " + numbers[i]);
        }

        // Declare and initialize a second array with the same values as the first array
        int[] numbersCopy = new int[] { 10, 20, 30, 40, 50 };

        // Use the SequenceEqual() method to compare the two arrays and print the result to the console
        bool arraysAreEqual = numbers.SequenceEqual(numbersCopy);
        Debug.Log("The two arrays are equal: " + arraysAreEqual);
    }
}
/*
This script first defines and initializes an integer array numbers with a size of 5, and assigns specific values to each element using the index operator. 
It then uses a for loop to iterate over the array and print each element to the console using the Debug.Log() method.
Next, the script declares and initializes a second array numbersCopy with the same values as the first array using an array initializer. 
Finally, the script uses the SequenceEqual() method from the LINQ library to compare the two arrays and prints the result to the console using the Debug.Log() method.
*/