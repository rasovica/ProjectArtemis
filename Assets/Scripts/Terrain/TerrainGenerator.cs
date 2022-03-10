using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int size = 0;
    public int x = 0;
    public int y = 0;

    public LevelData GenerateTerrain(BoundsInt bounds) {
        LevelData levelData = new LevelData();

        return levelData;
    }

    public void PlaceTerrain() {
        BoundsInt bounds = new BoundsInt();
        LevelData levelData = GenerateTerrain(bounds);
    }
}
