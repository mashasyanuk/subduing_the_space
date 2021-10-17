using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeGenerator2
{
    public int Width=30 ;
    public int Height =10;
    

    public Maze2 GenerateMaze()
    {

        MazeGeneratorCell2[,] cells = new MazeGeneratorCell2[Width, Height];

        for (int x = 0; x < cells.GetLength(0); x++)
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                cells[x, y] = new MazeGeneratorCell2 { X = x, Y = y };
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

        RemoveWallsWithBacktracker2(cells);

        Maze2 maze2 = new Maze2();

        maze2.cells = cells;
        maze2.finishPosition2 = PlaceMazeExit(cells);

        return maze2;
    }

    private void RemoveWallsWithBacktracker2(MazeGeneratorCell2[,] maze2)
    {
        MazeGeneratorCell2 current = maze2[0, 0];
        current.Visited = true;
        current.DistanceFromStart = 0;

        Stack<MazeGeneratorCell2> stack = new Stack<MazeGeneratorCell2>();
        do
        {
            List<MazeGeneratorCell2> unvisitedNeighbours = new List<MazeGeneratorCell2>();

            int x = current.X;
            int y = current.Y;

            if ((current.DistanceFromStart + 1) % 7 != 0)
            {
                current.coin = false;
            }
            if ((current.DistanceFromStart + 1) % 36 != 0)
            {
                current.portalBlue = false;

            }

            if ((current.DistanceFromStart + 1) % 51 != 0)
            {
                current.portalOrange = false;
            }



            if (x > 0 && ! maze2[x - 1, y].Visited) unvisitedNeighbours.Add(maze2[x - 1, y]);
            if (y > 0 && ! maze2[x, y - 1].Visited) unvisitedNeighbours.Add(maze2[x, y - 1]);
            if (x < Width - 2 && ! maze2[x + 1, y].Visited) unvisitedNeighbours.Add(maze2[x + 1, y]);
            if (y < Height - 2 && ! maze2[x, y + 1].Visited) unvisitedNeighbours.Add(maze2[x, y + 1]);

            if (unvisitedNeighbours.Count > 0)
            {
                MazeGeneratorCell2 chosen = unvisitedNeighbours[UnityEngine.Random.Range(0, unvisitedNeighbours.Count)];
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

    private void RemoveWall(MazeGeneratorCell2 a, MazeGeneratorCell2 b)
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

    private Vector2Int PlaceMazeExit(MazeGeneratorCell2[,] maze)
    {
        MazeGeneratorCell2 furthest = maze[0, 0];

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