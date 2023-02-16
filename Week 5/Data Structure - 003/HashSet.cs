using System.Collections.Generic;
using UnityEngine;

public class HashSetExample : MonoBehaviour
{
    void Start()
    {
        HashSet<string> names = new HashSet<string>();
        names.Add("John");
        names.Add("Mary");
        names.Add("Bob");
        names.Add("Mary"); // Adding duplicate item will be ignored

        foreach (string name in names)
        {
            Debug.Log(name);
        }
    }
}
//This script creates a HashSet of strings that contains four names, adds them to the HashSet (with one duplicate), 
//and then uses a foreach loop to print out each name to the console. Notice that the duplicate name is only added once to the HashSet.