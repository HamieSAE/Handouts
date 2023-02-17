using UnityEngine;
using System.Collections.Generic;

public class CalculationScript : MonoBehaviour
{
    private int[] results = new int[4];
    private int[] numbers = { 8, 10, 54, 70 };
    private int[] otherNumbers = { 15, 2, 30, 1 };

    void Start()
    {
        results[0] = numbers[0] + otherNumbers[0];
        results[1] = numbers[1] - otherNumbers[1];
        results[2] = numbers[2] * otherNumbers[2];
        results[3] = numbers[3] / otherNumbers[3];

        Debug.Log("Addition result: " + results[0]);
        Debug.Log("Subtraction result: " + results[1]);
        Debug.Log("Multiplication result: " + results[2]);
        Debug.Log("Division result: " + results[3]);
    }
}
/*
This script defines an array called results to store the results of the calculations. 
It then performs the four operations on the corresponding elements of the numbers and otherNumbers arrays and stores the results in the results array. 
Finally, it prints out the results to the console using Debug.Log().
*/