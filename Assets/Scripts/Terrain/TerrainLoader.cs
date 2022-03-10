using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

enum TerrainTypes: int {
    grass = 0,
    trees = 1,
}


public class TerrainLoader : MonoBehaviour {
    public Tilemap tilemap;
    public GameObject[] grassTiles;
    public GameObject[] treeTiles;

	void Start () {

	}

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
}
