using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // A private integer to store the health points of the enemy
    private int _healthpoints;
    // This method is called when the component is first enabled and active
    private void Awake()
    {
        // Set the initial health points to 30
        _healthpoints = 30;
    }
    // This method is used to subtract 10 health points from the enemy
    public bool TakeHit()
    {
        // Subtract 10 health points
        _healthpoints -= 10;
        // Check if the enemy is dead (i.e., its health points are less than or equal to 0)
        bool isDead = _healthpoints <= 0;
        // If the enemy is dead, call the _Die method
        if (isDead) _Die();
        // Return the value indicating whether the enemy is dead or not
        return isDead;
    }

    // This method is used to destroy the game object when the enemy dies
    private void _Die()
    {
        // Destroy the game object
        Destroy(gameObject);
    }
}