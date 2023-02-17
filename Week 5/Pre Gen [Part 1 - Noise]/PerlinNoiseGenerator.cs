using UnityEngine;

public class PerlinNoiseGenerator : MonoBehaviour
{
    // Public variables for setting the texture size and scale
    public int width = 256;
    public int height = 256;
    public float scale = 20f;

    // Called when the script is started
    private void Start()
    {
        // Create a new texture with the specified width and height
        Texture2D texture = new Texture2D(width, height);

        // Loop through each pixel in the texture
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Calculate the sample point for the current pixel using Perlin noise
                float xCoord = (float)x / width * scale;
                float yCoord = (float)y / height * scale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);

                // Set the pixel color based on the Perlin noise sample
                texture.SetPixel(x, y, new Color(sample, sample, sample));
            }
        }

        // Apply the changes to the texture
        texture.Apply();

        // Assign the texture to the material of the attached renderer component
        GetComponent<Renderer>().material.mainTexture = texture;
    }
}
/*
This script generates a 2D texture using Perlin noise, a type of procedural noise that is often used to create natural-looking textures and terrain in games.
The Start method is called when the script is started, and creates a new Texture2D object with the specified width and height. 
It then loops through each pixel in the texture, calculates a Perlin noise sample for the current pixel based on its position, and sets the pixel color based on the sample.
Finally, the changes are applied to the texture using the Apply method, and the texture is assigned to the main texture of the material used by the attached renderer component. 
This allows the texture to be seen when the object is rendered in the scene.

In this script, we use the Mathf.PerlinNoise function to generate Perlin noise values for each pixel in a texture. 
The scale parameter controls the frequency of the noise, and the width and height parameters set the size of the texture. Finally, we apply the texture to a material and use it to render a plane in the scene.
Note that this is a simple example and there are many ways to modify and enhance Perlin noise for more complex effects, such as combining multiple layers of noise or using different interpolation methods.
*/