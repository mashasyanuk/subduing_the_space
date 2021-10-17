using UnityEngine;

public class Maze1 
{
    public MazeGeneratorCell1[,] cells;
    public Vector2Int finishPosition1;
}

public class MazeGeneratorCell1
{
    public int X;
    public int Y;

    public bool WallLeft = true;
    public bool WallBottom = true;

    public bool Visited = false;

    public bool portalBlue = true;
    public bool portalOrange = true;
    public bool coin = true;

    public int DistanceFromStart;
}
