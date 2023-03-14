using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public int mazeWidth;
    public int mazeHeight;
    public GameObject wallPrefab;
    public GameObject floorPrefab;

    private int[,] maze;

    void Start()
    {
        maze = new int[mazeWidth, mazeHeight];
        GenerateMaze();
        DrawMaze();
    }

    void GenerateMaze()
    {
        // TODO: Implement maze generation algorithm
    }

    void DrawMaze()
    {
        for (int x = 0; x < mazeWidth; x++)
        {
            for (int y = 0; y < mazeHeight; y++)
            {
                if (maze[x, y] == 1)
                {
                    // Create a wall at the current position
                    Instantiate(wallPrefab, new Vector3(x, 0, y), Quaternion.identity);
                }
                else
                {
                    // Create a floor at the current position
                    Instantiate(floorPrefab, new Vector3(x, -0.5f, y), Quaternion.identity);
                }
            }
        }
    }
}
/* 
This script includes several variables and functions:

mazeWidth and mazeHeight are integers that determine the size of the maze to be generated.
wallPrefab and floorPrefab are GameObjects that will be used to create the maze. These can be set in the Unity editor by dragging and dropping prefabs into the relevant slots in the inspector panel for the MazeGenerator script.
maze is a two-dimensional integer array that will be used to represent the maze. A value of 1 represents a wall, while a value of 0 represents a floor.
In the Start() function, the maze array is initialized and then the GenerateMaze() and DrawMaze() functions are called. The GenerateMaze() function is not yet implemented - this is where you will need to add code to generate the maze.

In the DrawMaze() function, the maze array is iterated over and a wall or floor is created depending on the value of each cell. The Instantiate() function is used to create a new instance of the relevant prefab at the current position.

To generate a maze, you will need to implement an algorithm that sets the values in the maze array. One popular algorithm for maze generation is the recursive backtracking algorithm. Here is a possible implementation for this algorithm


void GenerateMaze()
{
    // Initialize the maze with walls
    for (int x = 0; x < mazeWidth; x++)
    {
        for (int y = 0; y < mazeHeight; y++)
        {
            maze[x, y] = 1;
        }
    }

    // Start at a random cell
    int startX = Random.Range(0, mazeWidth);
    int startY = Random.Range(0, mazeHeight);
    maze[startX, startY] = 0;

    // Recursively carve out the maze
    CarveMaze(startX, startY);
}

void CarveMaze(int x, int y)
{
    // Create a list of directions to try
    List<int> directions = new List<int> { 0, 1, 2, 3 };
    directions = Shuffle(directions);

    // Try each direction in a random order
    foreach (int direction in directions)
    {
        int dx = 0;
        int dy = 0;

        switch (direction)
        {
            case 0:
                dx = 0;
                dy = 1;
                break;
            case 1:
                dx = 1;
                dy = 0;
                break;
            case 2:
                dx = 0;
                dy = -1;
                break;
            case 3:
                dx = -1;
                dy = 0;
                break;
        }

        int nextX = x + dx;
        int nextY = y + dy;

        if (nextX < 0 || nextX >= mazeWidth || nextY < 0 || nextY >= mazeHeight)
        {
            continue;
        }

        if (maze[nextX, nextY] == 1)
        {
            maze[x + dx / 2, y + dy / 2] = 0;
            maze[nextX, nextY] = 0;
            CarveMaze(nextX, nextY);
        }
    }
}

List<T> Shuffle<T>(List<T> list)
{
    for (int i = 0; i < list.Count; i++)
    {
        T temp = list[i];
        int randomIndex = Random.Range(i, list.Count);
        list[i] = list[randomIndex];
        list[randomIndex] = temp;
    }
    return list;
}
The GenerateMaze() function initializes the maze with walls, then starts at a random cell and calls the CarveMaze() function to recursively carve out the maze.

The CarveMaze() function works as follows:

Create a list of directions to try, and shuffle the list to randomize the order in which directions are tried.
Try each direction in turn, and check if the cell in that direction can be carved out (i.e. if it is a wall).
If the cell can be carved out, set the current cell and the intermediate cell to be floors, and call CarveMaze() recursively with the next cell as the current cell.
The Shuffle() function is a helper function that shuffles a list in place using the Fisher-Yates shuffle algorithm.

Once the maze is generated, the DrawMaze() function iterates over the maze array and creates walls and floors as appropriate.
*/