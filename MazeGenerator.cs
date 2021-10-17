using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeGenerator 
{
    public int Width = 5 ; //задаем размер лабиринта
    public int Height = 5;
    

    public Maze GenerateMaze()
    {

        MazeGeneratorCell[,] cells = new MazeGeneratorCell[Width, Height]; //новый массив из клеток - префабов (сама клетка 1 на 1)

        for (int x = 0; x < cells.GetLength(0); x++) //заполняем полностью префабами
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                cells[x, y] = new MazeGeneratorCell { X = x, Y = y };
            }

        }

        for (int x = 0; x < cells.GetLength(0); x++) //
        {
            cells[x, Height - 1].WallLeft = false;
            cells[x, Height - 1].coin = false;
            cells[x, Height - 1].portalOrange = false;
            cells[x, Height - 1].portalBlue = false;
        }

        for (int y = 0; y < cells.GetLength(1); y++)
        {
            cells[Width - 1, y].WallBottom = false;
            cells[Width - 1, y].coin= false;
            cells[Width - 1, y].portalBlue = false;
            cells[Width - 1, y].portalOrange = false;
        }

        RemoveWallsWithBacktracker(cells); //удаляем стены по алгоритму

        Maze maze = new Maze();

        maze.cells = cells;
        maze.finishPosition = PlaceMazeExit(cells); //делаем выход

        return maze;
    }

    private void RemoveWallsWithBacktracker(MazeGeneratorCell[,] maze) //как удаляются стены
    {
        MazeGeneratorCell current = maze[0, 0];
        current.Visited = true;
        current.DistanceFromStart = 0;

        Stack<MazeGeneratorCell> stack = new Stack<MazeGeneratorCell>();
        do
        {
            List<MazeGeneratorCell> unvisitedNeighbours = new List<MazeGeneratorCell>(); 

            int x = current.X;
            int y = current.Y;

            if ((current.DistanceFromStart + 1) % 2 != 0) // пронумерованные ячейки заполняются монетами, порталами
            {
                current.coin = false;
            }
            if ((current.DistanceFromStart + 1) % 17 != 0)
            {
                current.portalBlue = false;

            }

            if ((current.DistanceFromStart + 1) % 23 != 0)
            {
                current.portalOrange = false;
            }

            if (x > 0 && !maze[x - 1, y].Visited) unvisitedNeighbours.Add(maze[x - 1, y]); //добавляются стенки по краям
            if (y > 0 && !maze[x, y - 1].Visited) unvisitedNeighbours.Add(maze[x, y - 1]);
            if (x < Width - 2 && !maze[x + 1, y].Visited) unvisitedNeighbours.Add(maze[x + 1, y]);
            if (y < Height - 2 && !maze[x, y + 1].Visited) unvisitedNeighbours.Add(maze[x, y + 1]);

            if (unvisitedNeighbours.Count > 0) //если у клетки есть непосещенные соседи
            {
                MazeGeneratorCell chosen = unvisitedNeighbours[UnityEngine.Random.Range(0, unvisitedNeighbours.Count)]; //выбираем случайного соседа
                RemoveWall(current, chosen); //убираем стену между текущей и сосендней точками

                chosen.Visited = true;
                stack.Push(chosen);
                chosen.DistanceFromStart = current.DistanceFromStart + 1;
                current = chosen;
            }
            else //если нет соседей, возвращаемся на предыдущую точку
            {
                current = stack.Pop();
            }
        } while (stack.Count > 0);
    }

    private void RemoveWall(MazeGeneratorCell a, MazeGeneratorCell b) //скрипт отключения стен в лабиринте
    {
        if (a.X == b.X)
        {
            if (a.Y > b.Y) a.WallBottom = false;
            else b.WallBottom = false;
        }
        else
        {
            if (a.X > b.X) a.WallLeft = false;
            else b.WallLeft = false;
        }
    }

    private Vector2Int PlaceMazeExit(MazeGeneratorCell[,] maze) //как находится выход в лабиринте
    {
        MazeGeneratorCell furthest = maze[0, 0];

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            if (maze[x, Height - 2].DistanceFromStart > furthest.DistanceFromStart) furthest = maze[x, Height - 2];
            if (maze[x, 0].DistanceFromStart > furthest.DistanceFromStart) furthest = maze[x, 0];
        }

        for (int y = 0; y < maze.GetLength(1); y++)
        {
            if (maze[Width - 2, y].DistanceFromStart > furthest.DistanceFromStart) furthest = maze[Width - 2, y];
            if (maze[0, y].DistanceFromStart > furthest.DistanceFromStart) furthest = maze[0, y];
        }

        if (furthest.X == 0) furthest.WallLeft = false;
        else if (furthest.Y == 0) furthest.WallBottom = false;
        else if (furthest.X == Width - 2) maze[furthest.X + 1, furthest.Y].WallLeft = false;
        else if (furthest.Y == Height - 2) maze[furthest.X, furthest.Y + 1].WallBottom = false;

        return new Vector2Int(furthest.X, furthest.Y);
    }
}