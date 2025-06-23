using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject tilePrefab;

    private int width = 4;
    private int height = 3;

    void Start()
    {
        GenerateSimpleMap();
    }

    void GenerateSimpleMap()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector3 pos = new Vector3(x, y, 0);
                GameObject tile = Instantiate(tilePrefab, pos, Quaternion.identity);
                tile.name = $"Tile_{x}_{y}_0";
                tile.transform.parent = this.transform;

                var ctrl = tile.GetComponent<TileController>();
                ctrl.x = x;
                ctrl.y = y;
                ctrl.z = 0;
                ctrl.tileId = (x + y) % 3 + 1; // 예: tileId = 1~3
                ctrl.SetColor(new Color(0.8f, 0.8f, 1f)); // 옅은 파랑
            }
        }

        // 2단 겹침 예시
        Vector3 posTop = new Vector3(2, 1.5f, 0);
        GameObject topTile = Instantiate(tilePrefab, posTop, Quaternion.identity);
        topTile.name = "Tile_2_1_1";
        topTile.transform.parent = this.transform;

        var topCtrl = topTile.GetComponent<TileController>();
        topCtrl.x = 2;
        topCtrl.y = 1;
        topCtrl.z = 1;
        topCtrl.tileId = 99;
        topCtrl.SetColor(Color.red);
    }
}
