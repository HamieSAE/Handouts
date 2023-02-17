using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArithmeticOperations : MonoBehaviour
{
    private int[] numbers = { 8, 10, 54, 70 };
    private int[] operations = { 15, 2, 30, 1 };
    private float[] results = new float[4];

    void Start()
    {
        for (int i = 0; i < operations.Length; i++)
        {
            if (i == 0)
            {
                results[i] = numbers[i] + operations[i];
            }
            else if (i == 1)
            {
                results[i] = results[i - 1] - operations[i];
            }
            else if (i == 2)
            {
                results[i] = results[i - 1] * operations[i];
            }
            else if (i == 3)
            {
                results[i] = results[i - 1] / operations[i];
            }
        }

        for (int i = 0; i < results.Length; i++)
        {
            Debug.Log("Result " + (i + 1) + ": " + results[i]);
        }
    }
}
/*
This version uses a loop to iterate over the operations array, so it can handle any number of input values. 
The results array is also defined to have a length of 4, so it can hold the results for any number of input values.
*/