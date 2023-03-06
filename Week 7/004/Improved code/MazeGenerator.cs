using UnityEngine;
using System.Collections.Generic;

public class MazeGenerator : MonoBehaviour
{
    public int width; // The width of the maze
    public int height; // The height of the maze
    public float wallHeight = 1f; // The height of the walls
    public GameObject wallPrefab; // The prefab for the walls
    public float scale = 1f; // The scale of the Perlin noise
    public float threshold = 0.5f; // The threshold for the Perlin noise

    private List<GameObject> walls; // A list of all the walls in the maze

    void Start()
    {
        GenerateMaze();
    }

    void GenerateMaze()
    {
        walls = new List<GameObject>(); // Initialize the list of walls

        // Loop through each cell in the maze
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float noise = Mathf.PerlinNoise(x * scale, y * scale); // Get the Perlin noise value for the current cell

                if (noise > threshold) // If the noise value is greater than the threshold, add a wall
                {
                    // Calculate the position of the wall
                    Vector3 position = new Vector3(x, wallHeight / 2f, y);
                    // Instantiate the wall prefab at the position
                    GameObject wall = Instantiate(wallPrefab, position, Quaternion.identity) as GameObject;
                    // Set the scale of the wall to fit the cell
                    wall.transform.localScale = new Vector3(1f, wallHeight, 1f);
                    // Add the wall to the list of walls
                    walls.Add(wall);
                }
            }
        }
    }

    void ClearMaze()
    {
        // Destroy all the walls in the maze
        foreach (GameObject wall in walls)
        {
            Destroy(wall);
        }
        // Clear the list of walls
        walls.Clear();
    }

    void OnValidate()
    {
        // Generate a new maze whenever the script parameters are changed in the editor
        ClearMaze();
        GenerateMaze();
    }
}
