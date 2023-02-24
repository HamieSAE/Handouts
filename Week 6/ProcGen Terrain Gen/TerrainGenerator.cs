using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int width = 256;             // Width of the terrain
    public int height = 256;            // Height of the terrain
    public int depth = 20;              // Depth of the terrain

    public float scale = 20f;           // Scale of the terrain
    public float offsetX = 100f;        // Offset of the x-coordinate
    public float offsetY = 100f;        // Offset of the y-coordinate
    
    // Start is called before the first frame update
    void Start()
    {
        // Generate random offsets
        offsetX = Random.Range(0f, 9999f);
        offsetY = Random.Range(0f, 9999f);

        // Get the terrain component and generate the terrain
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    // Generate the terrain data
    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        // Set the heightmap resolution and size of the terrain data
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);

        // Generate the heights of the terrain and set it to the terrain data
        terrainData.SetHeights(0, 0, GenerateHeights());

        return terrainData;
    }

    // Generate the heights of the terrain
    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, depth];

        // Loop through each x and y coordinate to generate the heights
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    // Calculate the height at the given x and y coordinate
    float CalculateHeight(int x, int y)
    {
        // Calculate the x and y coordinate based on the given scale and offset
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / depth * scale + offsetY;

        // Generate the height using Perlin noise and return it
        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
/*
This script generates a terrain using Perlin noise. 
It does this by generating random offsets, 
    setting the heightmap resolution and size of the terrain, 
    generating the heights of the terrain using Perlin noise, 
    and setting the heights to the terrain data. 
The height of each point in the terrain is calculated based on the x and y coordinate, the scale, and the offset using Perlin noise.
*/