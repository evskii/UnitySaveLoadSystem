using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsageExample : MonoBehaviour
{
    void Start() {
        // List<SaveLoadSystem.DataBlock> dataBlocksToSave = new List<SaveLoadSystem.DataBlock>();
        // dataBlocksToSave.Add(new SaveLoadSystem.DataBlock("Age", 24));
        // dataBlocksToSave.Add(new SaveLoadSystem.DataBlock("Strength", 58));
        // dataBlocksToSave.Add(new SaveLoadSystem.DataBlock("Dex", 15));
        // dataBlocksToSave.Add(new SaveLoadSystem.DataBlock("Money", 3000));
        // SaveLoadSystem.Save(dataBlocksToSave.ToArray());
        // Debug.Log(PlayerPrefs.GetString("SaveData"));
        Debug.Log(SaveLoadSystem.LoadAll()[0].identifier);
        Debug.Log(SaveLoadSystem.LoadAll()[1].identifier);
        Debug.Log(SaveLoadSystem.LoadAll()[2].identifier);
        Debug.Log(SaveLoadSystem.LoadAll()[3].identifier);
    }

}
