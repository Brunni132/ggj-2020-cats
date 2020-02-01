using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile fullTile, replaceableTile, fishSpawnTile;
    public GameObject fishPrefab;
    private static Random random = new Random();

    private TileBase GetTile(int x, int y) {
        return tilemap.GetTile(new Vector3Int(x, y, 0));
    }

    private void SetTile(int x, int y, TileBase tile) {
        tilemap.SetTile(new Vector3Int(x, y, 0), tile);
    }

    private void spawnFish(int tileX, int tileY) {
        var worldPos = tilemap.CellToWorld(new Vector3Int(tileX, tileY, 0));
        Instantiate(fishPrefab, worldPos + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
    }


    private void makeWall(ref int xStart, int y) {
        int xEnd = xStart;
        int replaceableTiles = 0;
        while (GetTile(xEnd, y) == replaceableTile || GetTile(xEnd + 1, y) == replaceableTile) {
            if (GetTile(xEnd, y) == replaceableTile) replaceableTiles++;
            xEnd++;
        }

        int openedPath1 = Random.Range(0, replaceableTiles);
        int tileId = 0;
        // if (Random.Range(0, 2) == 1) openedPath2 = openedPath1;
        for (int i = xStart; i < xEnd; i++) {
            if (GetTile(i, y) == replaceableTile) {
                SetTile(i, y, openedPath1 == tileId ? null : fullTile);
                tileId++;
            }
        }

        xStart = xEnd;
    }

    // Start is called before the first frame update
    void Start()
    {
        // for (int i = 0; i < 200; i++) {
        //     for (int j = 0; j < 200; j++) {
        //         var tile = tilemap.GetTile(new Vector3Int(i, j, 0));
        //         if (tile != null) UnityEngine.Debug.LogWarningFormat("TEMP tile {0} {1} {2}", tile, i, j);
        //     }
        // }

        for (int j = tilemap.cellBounds.yMin; j < tilemap.cellBounds.yMax; j++) {
            for (int i = tilemap.cellBounds.xMin; i < tilemap.cellBounds.xMax; i++) {
                if (GetTile(i, j) == replaceableTile) {
                    makeWall(ref i, j);
                }
            }
        }

        // Count the number of cells which can spawn a fish
        int fishSpawnable = 0;
        for (int j = tilemap.cellBounds.yMin; j < tilemap.cellBounds.yMax; j++) {
            for (int i = tilemap.cellBounds.xMin; i < tilemap.cellBounds.xMax; i++) {
                if (GetTile(i, j) == fishSpawnTile) fishSpawnable++;
            }
        }

        // Spawn the fish
        int tileId = 0, fishSpawnId = Random.Range(0, fishSpawnable);
        for (int j = tilemap.cellBounds.yMin; j < tilemap.cellBounds.yMax; j++) {
            for (int i = tilemap.cellBounds.xMin; i < tilemap.cellBounds.xMax; i++) {
                if (GetTile(i, j) == fishSpawnTile) {
                    if (tileId++ == fishSpawnId) spawnFish(i, j);
                    SetTile(i, j, null);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
