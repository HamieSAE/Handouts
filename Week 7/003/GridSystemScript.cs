using UnityEngine;

public class GridSystemScript : MonoBehaviour
{
    public GameObject tilePrefab;   // Reference to the tile prefab game object
    public int numTilesX;           // Number of tiles in the X direction
    public int numTilesY;           // Number of tiles in the Y direction
    public float tileSize;         // Size of each tile
    public float spacing;           // Spacing between each tile

    void Start()
    {
        GenerateGrid();             // Call the GenerateGrid function when the script starts
    }

    void GenerateGrid()
    {
        // Loop through each tile in the X direction
        for (int x = 0; x < numTilesX; x++)
        {
            // Loop through each tile in the Y direction
            for (int y = 0; y < numTilesY; y++)
            {
                // Calculate the position of the tile based on the current X and Y values, tile size, and spacing
                Vector3 position = new Vector3(x * (tileSize + spacing), 0f, y * (tileSize + spacing));

                // Instantiate a new tile prefab at the calculated position and rotation
                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);

                // Set the parent of the tile to this game object
                tile.transform.parent = transform;
            }
        }
    }
}
/*Remember to also create a tile prefab game object and drag it onto the "tilePrefab" field in the inspector. Set the desired values for numTilesX, numTilesY, tileSize, and spacing in the inspector as well.*/