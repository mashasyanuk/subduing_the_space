using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public cell CellPrefab;
    public Vector3 CellSize = new Vector3(1, 1, 0);
    public HintRenderer HintRenderer;

    public Maze maze;

    private void Start()
    {
        MazeGenerator generator = new MazeGenerator();
        maze = generator.GenerateMaze();

        for (int x = 0; x < maze.cells.GetLength(0); x++) //хаполняется лабиринт полностью префабами
        {
            for (int y = 0; y < maze.cells.GetLength(1); y++)
            {
                cell c = Instantiate(CellPrefab, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);

                c.wallLeft.SetActive(maze.cells[x, y].WallLeft);
                c.wallBottom.SetActive(maze.cells[x, y].WallBottom);

                c.coin.SetActive(maze.cells[x, y].coin);
                c.portalBlue.SetActive(maze.cells[x, y].portalBlue);
                c.portalOrange.SetActive(maze.cells[x, y].portalOrange);

            }
        }

        HintRenderer.DrawPath();
    }
}