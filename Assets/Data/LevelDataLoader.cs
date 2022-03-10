using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LevelDataLoader
{
    private const string LevelPath = "chunk1";
 
    public LevelData ReadLevelData()
    {
        var jsonFile = Resources.Load(LevelPath, typeof(TextAsset)) as TextAsset;
        if (jsonFile == null)
        {
            throw new ApplicationException("Levels file is not accessible");
        }
 
        return JsonUtility.FromJson<LevelData>(jsonFile.text);
    }
}