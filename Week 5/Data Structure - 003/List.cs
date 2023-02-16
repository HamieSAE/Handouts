using System.Collections.Generic;
using UnityEngine;

public class ListExample : MonoBehaviour
{
    void Start()
    {
        List<string> fruits = new List<string>();
        fruits.Add("Apple");
        fruits.Add("Banana");
        fruits.Add("Orange");
        
        foreach (string fruit in fruits)
        {
            Debug.Log(fruit);
        }
    }
}
//This script creates a List of strings that contains three fruits, adds them to the list, and then uses a foreach loop to print out each fruit to the console.