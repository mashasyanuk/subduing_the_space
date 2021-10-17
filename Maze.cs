using UnityEngine;

public class Maze //обьявляем класс, на который будем ссылаться, для другого скрипта 
{
    public MazeGeneratorCell[,] cells;
    public Vector2Int finishPosition;
}

public class MazeGeneratorCell //обьявляем класс для другого скрипта
{
    public int X;
    public int Y;

    public bool WallLeft = true;
    public bool WallBottom = true;

    public bool portalBlue = true ;
    public bool portalOrange = true;
    public bool coin = true ;

    public bool Visited = false;
    public int DistanceFromStart;


}
