using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileInfo : MonoBehaviour {
    public Tilemap tilemap;

    private Vector3Int location;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log(tilemap.GetTilesBlock(tilemap.cellBounds));
            Debug.Log(tilemap.GetTilesBlock(tilemap.cellBounds).Length);

            foreach (TileBase tile in tilemap.GetTilesBlock(tilemap.cellBounds)) {
                Debug.Log(tile);
                if (tile != null) {
                    Debug.Log(tile.name);
                }
            }
        }    
    }
}
