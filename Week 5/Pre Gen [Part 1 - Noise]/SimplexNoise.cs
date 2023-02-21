using UnityEngine;
using FastNoiseWrapper;

public class SimplexNoise : MonoBehaviour
{
    public float scale = 1f;    // Controls the zoom level of the noise
    public float speed = 1f;    // Controls the speed of the noise animation

    private FastNoise _noise;   // FastNoise library for generating noise

    void Start()
    {
        _noise = new FastNoise();   // Create a new FastNoise object
        _noise.SetNoiseType(FastNoise.NoiseType.Simplex);   // Set the noise type to Simplex
    }

    void Update()
    {
        _noise.SetFrequency(scale);   // Set the noise frequency
        _noise.SetSeed((int)(Time.time * speed));   // Set the noise seed based on time
        float noiseValue = _noise.GetNoise(transform.position.x, transform.position.z);   // Get the noise value for the current position
        transform.position = new Vector3(transform.position.x, noiseValue, transform.position.z);   // Move the object based on the noise value
    }
}
/*
The SimplexNoise class inherits from the MonoBehaviour class, which is a base class for Unity scripts that allows them to interact with the game engine.
The class has two public float variables, scale and speed, that control the zoom level and speed of the noise animation.
In the Start method, a new FastNoise object is created, and the noise type is set to Simplex.
In the Update method, the noise frequency and seed are set based on the public variables scale and speed multiplied by the current time. 
The noise value is then obtained for the current position of the Transform component attached to the game object the script is attached to, using transform.position.x and transform.position.z. 
Finally, the game object is moved vertically based on the noise value using the Vector3 class.
This script can be used to create a variety of effects in Unity, such as terrain generation, water effects, or cloud movement, by manipulating the public variables and using the noise value in different ways.
*/