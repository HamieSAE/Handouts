using UnityEngine;

public class LODScript : MonoBehaviour
{
    public Material[] materials;  // An array of materials to change to
    public float[] distances;    // An array of distances at which to change materials
    public Renderer rend;        // The renderer component of the object to change materials on

    void Start()
    {
        rend = GetComponent<Renderer>();  // Get the renderer component of the object
    }

    void Update()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            if (Vector3.Distance(transform.position, Camera.main.transform.position) <= distances[i])
            {
                rend.material = materials[i];  // Change the material to the one at index i
                break;  // Exit the loop once we've found the correct material
            }
        }
    }
}
/*
This script uses an array of materials and an array of distances to determine when to change the material of the object. 
The Renderer component of the object is obtained in the Start() method, and in the Update() method, the script checks the distance between the object and the camera. 
If the distance is less than or equal to one of the distances in the distances array, the material of the object is changed to the one at the same index in the materials array.
Attach the script to the object you want to change the material on. You'll need to add at least two materials to the materials array, as well as two distances to the distances array. 
The first distance should be the maximum distance at which the object should display the first material, and the second distance should be the minimum distance at which the object should switch to the second material.
You can add additional materials and distances if you want more levels of detail.
Test the script by moving the camera closer to and farther away from the object. You should see the material change as the camera gets closer to the object.
*/