using UnityEngine;

public class PerlinNoiseGeneratorColor : MonoBehaviour
{
    // Public variables for setting the texture size and scale
    public int width = 256;
    public int height = 256;
    public float scale = 20f;

    // Called when the script is started
   void Start()
{
    renderer = GetComponent<Renderer>();   // Get the Renderer component of the object this script is attached to
    noiseTexture = new Texture2D(width, height);  // Create a new Texture2D object with the specified dimensions

    for (int x = 0; x < width; x++)   // Iterate over the x-coordinates of the texture
    {
        for (int y = 0; y < height; y++)  // Iterate over the y-coordinates of the texture
        {
            float xCoord = (float)x / width * scale;  // Calculate the x-coordinate in the Perlin noise space
            float yCoord = (float)y / height * scale;  // Calculate the y-coordinate in the Perlin noise space
            float sample = Mathf.PerlinNoise(xCoord, yCoord);  // Get the Perlin noise value at the specified coordinates
            Color color = new Color(sample, sample, sample) * gradient.Evaluate(sample); // Create a new color using the Perlin noise value and a gradient texture
            noiseTexture.SetPixel(x, y, color); // Set the color of the pixel at the specified coordinates in the texture
        }
    }

    noiseTexture.Apply();  // Apply the changes made to the texture
    renderer.material.mainTexture = noiseTexture; // Set the texture as the main texture of the object's material
}

}
/*
This script generates a Perlin noise texture with the specified dimensions and applies it to the object's material. 
The noise texture is generated by iterating over the x- and y-coordinates of the texture and calculating the corresponding coordinates in the Perlin noise space. 
The Perlin noise value at these coordinates is then used to create a color, which is assigned to the corresponding pixel in the texture. 
Finally, the changes made to the texture are applied and the texture is assigned as the main texture of the object's material.
*/