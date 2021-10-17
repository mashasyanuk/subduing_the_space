using UnityEngine;

public class MazeSpawner1 : MonoBehaviour
{
    public cell CellPrefab;
    public Vector3 CellSize = new Vector3(1, 1, 0);
    public HintRenderer HintRenderer;

    public Maze1 maze1;

    private void Start()
    {
        MazeGenerator1 generator = new MazeGenerator1();
        maze1 = generator.GenerateMaze();

        for (int x = 0; x < maze1.cells.GetLength(0); x++)
        {
            for (int y = 0; y < maze1.cells.GetLength(1); y++)
            {
                cell c = Instantiate(CellPrefab, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);

                c.wallLeft.SetActive(maze1.cells[x, y].WallLeft);
                c.wallBottom.SetActive(maze1.cells[x, y].WallBottom);
                c.coin.SetActive(maze1.cells[x, y].coin);
                c.portalBlue.SetActive(maze1.cells[x, y].portalBlue);
                c.portalOrange.SetActive(maze1.cells[x, y].portalOrange);
            }
        }

        HintRenderer.DrawPath();
    }
}