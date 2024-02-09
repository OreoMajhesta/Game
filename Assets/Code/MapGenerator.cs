using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap obstacleTilemap;
    [SerializeField] private TileBase[] groundTiles; // Array of ground tiles
    [SerializeField] private TileBase[] obstacleTiles; // Array of obstacle tiles

    [SerializeField, Range(0f, 1f)] private float obstacleProbability = 0.1f;

    [SerializeField] private int mapWidth = 10; // Adjust the width of the map as needed
    [SerializeField] private int mapHeight = 10; // Adjust the height of the map as needed

    void Awake()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        if (groundTilemap == null || obstacleTilemap == null)
        {
            Debug.LogError("Tilemap tidak diassign pada Map Generator.");
            return;
        }

        // Menambahkan lebar dan tinggi peta untuk akomodasi batas
        int borderedMapWidth = mapWidth + 2;
        int borderedMapHeight = mapHeight + 2;

        for (int x = 0; x < borderedMapWidth; x++)
        {
            for (int y = 0; y < borderedMapHeight; y++)
            {
                Vector3Int cellPosition = new Vector3Int(x, y, 0);

                // Memeriksa apakah posisi saat ini berada di batas
                bool isBorder = x == 0 || x == borderedMapWidth - 1 || y == 0 || y == borderedMapHeight - 1;

                // Jika berada di batas, tentukan ground tile khusus untuk batas; jika tidak, atur ground tile secara acak
                TileBase selectedGroundTile = isBorder ? groundTiles[0] : groundTiles[Random.Range(0, groundTiles.Length)];

                // Atur ground tile pada groundTilemap
                groundTilemap.SetTile(cellPosition, selectedGroundTile);

                // Tempatkan obstacle dengan probabilitas tertentu, tapi tidak pada batas
                if (!isBorder && Random.Range(0f, 1f) < obstacleProbability)
                {
                    // Gunakan nilai acak untuk menentukan obstacle tile yang akan diatur
                    int obstacleRandomIndex = Random.Range(0, obstacleTiles.Length);
                    TileBase selectedObstacleTile = obstacleTiles[obstacleRandomIndex];

                    // Atur obstacle tile pada obstacleTilemap
                    obstacleTilemap.SetTile(cellPosition, selectedObstacleTile);
                }
            }
        }
    }

}
