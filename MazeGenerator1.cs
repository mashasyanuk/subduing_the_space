using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeGenerator1
{
    public int Width = 10 ;
    public int Height = 10;
    

    public Maze1 GenerateMaze()
    {

        MazeGeneratorCell1[,] cells = new MazeGeneratorCell1[Width, Height];

        for (int x = 0; x < cells.GetLength(0); x++)
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                cells[x, y] = new MazeGeneratorCell1 { X = x, Y = y };
            }
        }

        for (int x = 0; x < cells.GetLength(0); x++)
        {
            cells[x, Height - 1].WallLeft = false;
            cells[x, Height - 1].coin = false;
            cells[x, Height - 1].portalOrange = false;
            cells[x, Height - 1].portalBlue = false;
        }

        for (int y = 0; y < cells.GetLength(1); y++)
        {
            cells[Width - 1, y].WallBottom = false;
            cells[Width - 1, y].coin = false;
            cells[Width - 1, y].portalBlue = false;
            cells[Width - 1, y].portalOrange = false;
        }

        RemoveWallsWithBacktracker1(cells);

        Maze1 maze1 = new Maze1();

        maze1.cells = cells;
        maze1.finishPosition1 = PlaceMazeExit(cells);

        return maze1;
    }

    private void RemoveWallsWithBacktracker1(MazeGeneratorCell1[,] maze1)
    {
        MazeGeneratorCell1 current = maze1[0, 0];
        current.Visited = true;
        current.DistanceFromStart = 0;

        Stack<MazeGeneratorCell1> stack = new Stack<MazeGeneratorCell1>();
        do
        {
            List<MazeGeneratorCell1> unvisitedNeighbours = new List<MazeGeneratorCell1>();

            int x = current.X;
            int y = current.Y;

            if ((current.DistanceFromStart + 1) % 5 != 0)
            {
                current.coin = false;
            }
            if ((current.DistanceFromStart + 1) % 39 != 0)
            {
                current.portalBlue = false;

            }

            if ((current.DistanceFromStart + 1) % 29 != 0)
            {
                current.portalOrange = false;
            }

            if (x > 0 && ! maze1[x - 1, y].Visited) unvisitedNeighbours.Add(maze1[x - 1, y]);
            if (y > 0 && ! maze1[x, y - 1].Visited) unvisitedNeighbours.Add(maze1[x, y - 1]);
            if (x < Width - 2 && ! maze1[x + 1, y].Visited) unvisitedNeighbours.Add(maze1[x + 1, y]);
            if (y < Height - 2 && ! maze1[x, y + 1].Visited) unvisitedNeighbours.Add(maze1[x, y + 1]);

            if (unvisitedNeighbours.Count > 0)
            {
                MazeGeneratorCell1 chosen = unvisitedNeighbours[UnityEngine.Random.Range(0, unvisitedNeighbours.Count)];
                RemoveWall(current, chosen);

                chosen.Visited = true;
                stack.Push(chosen);
                chosen.DistanceFromStart = current.DistanceFromStart + 1;
                current = chosen;
            }
            else
            {
                current = stack.Pop();
            }
        } while (stack.Count > 0);
    }

    private void RemoveWall(MazeGeneratorCell1 a, MazeGeneratorCell1 b)
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

    private Vector2Int PlaceMazeExit(MazeGeneratorCell1[,] maze)
    {
        MazeGeneratorCell1 furthest = maze[0, 0];

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