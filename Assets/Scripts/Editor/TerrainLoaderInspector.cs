using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TerrainLoader))]
public class TerrainLoaderInspector : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        TerrainLoader terrainLoader = (TerrainLoader)target;

        if (GUILayout.Button("Load")) {
            terrainLoader.LoadTerrain();
        }
    }
}
