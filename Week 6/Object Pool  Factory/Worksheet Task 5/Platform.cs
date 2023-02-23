using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) // Called when another collider enters the trigger area of this object
    {
        if (other.CompareTag("Player")) // Check if the entering collider has the tag "Player"
        {
            other.transform.SetParent(transform); // Set the entering collider's parent to this object
        }
    }
}
/*
This script is attached to a platform object, and when a collider with the tag "Player" enters the trigger area of the platform, the player object's parent transform is set to the platform. 
This is commonly used in platformers to make the player character move along with moving platforms.
*/