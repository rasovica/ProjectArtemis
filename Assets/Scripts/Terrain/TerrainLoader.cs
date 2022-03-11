using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

enum TerrainTypes: int {
    grass = 0,
    trees = 1,
}


public class TerrainLoader : MonoBehaviour {
    public Tilemap tilemap;
    public BoundsInt bounds;

    public GameObject[] grassTiles;
    public GameObject[] treeTiles;

    public void LoadTerrain (LevelData levelDataProp = null) {
        tilemap.ClearAllTiles();
        tilemap.RefreshAllTiles();
        LevelData levelData;

        if (levelDataProp == null) {
            LevelDataLoader loader = new LevelDataLoader();
            levelData = loader.ReadLevelData();
        } else {
            levelData = levelDataProp;
        }

        Debug.Log(string.Format("Number of tiles: {0}", levelData.tiles.Length));

        foreach (LevelData.LevelDataTile dataTile in levelData.tiles) {            
            Tile tile = (Tile) ScriptableObject.CreateInstance(typeof(Tile));
            switch (dataTile.id) {
                case (int)TerrainTypes.grass:
                    int index = (dataTile.cords[0] + dataTile.cords[1]) % grassTiles.Length;
                    tile.gameObject = grassTiles[index];
                    break;
                case (int)TerrainTypes.trees:
                    int index2 = (dataTile.cords[0] + dataTile.cords[1]) % treeTiles.Length;
                    tile.gameObject = treeTiles[index2];
                    break;
            }

            tilemap.SetTile(new Vector3Int(dataTile.cords[0], dataTile.cords[1], 0), tile);
        }
    }

    public LevelData GenerateTerrain() {
        LevelData levelData = new LevelData();
        LevelData.LevelDataTile[] tiles = new LevelData.LevelDataTile[100 * 100];
        levelData.tiles = tiles;
        int index = 0;

        foreach (Vector3Int position in bounds.allPositionsWithin) {
            LevelData.LevelDataTile tile = new LevelData.LevelDataTile();
            tile.id = 0;
            tile.cords = new int[] {position.x, position.y};
            levelData.tiles[index] = tile;
            index = index + 1;
        }
        levelData.tiles = tiles;

        return levelData;
    }

    public void PlaceTerrain() {
        LevelData levelData = GenerateTerrain();

        LoadTerrain(levelData);
    }
}
