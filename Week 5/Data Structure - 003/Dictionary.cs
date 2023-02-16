using System.Collections.Generic;
using UnityEngine;

public class DictionaryExample : MonoBehaviour
{
    void Start()
    {
        Dictionary<string, int> ages = new Dictionary<string, int>();
        ages.Add("John", 25);
        ages.Add("Mary", 30);
        ages.Add("Bob", 35);

        int maryAge = ages["Mary"];
        Debug.Log("Mary's age is " + maryAge);
    }
}
//This script creates a Dictionary that maps strings (names) to integers (ages), 
//adds three items to the Dictionary, and then retrieves and prints out the age of Mary.