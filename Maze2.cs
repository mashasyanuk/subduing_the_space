using UnityEngine;

public class Maze2
{
    public MazeGeneratorCell2[,] cells;
    public Vector2Int finishPosition2;
}

public class MazeGeneratorCell2
{
    public int X;
    public int Y;

    public bool WallLeft = true;
    public bool WallBottom = true;

    public bool portalBlue = true;
    public bool portalOrange = true;
    public bool coin = true;


    public bool Visited = false;
    public int DistanceFromStart;
}
