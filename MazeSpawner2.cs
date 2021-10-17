using UnityEngine;

public class MazeSpawner2 : MonoBehaviour
{
    public cell CellPrefab;
    public Vector3 CellSize = new Vector3(1, 1, 0);
    public HintRenderer HintRenderer;

    public Maze2 maze2;

    private void Start()
    {
        MazeGenerator2 generator = new MazeGenerator2();
        maze2 = generator.GenerateMaze();

        for (int x = 0; x < maze2.cells.GetLength(0); x++)
        {
            for (int y = 0; y < maze2.cells.GetLength(1); y++)
            {
                cell c = Instantiate(CellPrefab, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);

                c.wallLeft.SetActive(maze2.cells[x, y].WallLeft);
                c.wallBottom.SetActive(maze2.cells[x, y].WallBottom);
                c.coin.SetActive(maze2.cells[x, y].coin);
                c.portalBlue.SetActive(maze2.cells[x, y].portalBlue);
                c.portalOrange.SetActive(maze2.cells[x, y].portalOrange);
            }
        }

        HintRenderer.DrawPath();
    }
}