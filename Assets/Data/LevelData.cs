using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class LevelData
{
    public LevelDataTile[] tiles;
    
    [Serializable]
    public class LevelDataTile
    {
        public int id;
        public int[] cords;
    }
}