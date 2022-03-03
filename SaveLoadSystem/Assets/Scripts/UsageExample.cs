using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsageExample : MonoBehaviour
{
    void Start() {
        
        List<SaveLoadSystem.DataBlock> dataBlocksToSave = new List<SaveLoadSystem.DataBlock>();
        dataBlocksToSave.Add(new SaveLoadSystem.DataBlock("Age", 28));
        // dataBlocksToSave.Add(new SaveLoadSystem.DataBlock("Strength", 18));
        // dataBlocksToSave.Add(new SaveLoadSystem.DataBlock("Dex", 10));
        // dataBlocksToSave.Add(new SaveLoadSystem.DataBlock("Money", 3000));
        dataBlocksToSave.Add(new SaveLoadSystem.DataBlock("Souls", 83));
        SaveLoadSystem.Save(dataBlocksToSave.ToArray());
        
        // Debug.Log(PlayerPrefs.GetString("SaveData"));
        // Debug.Log(SaveLoadSystem.LoadAll()[0].identifier);
        // var temp = SaveLoadSystem.LoadAll();
        // Debug.Log(temp[0].value + temp[3].value);

        // // Example of how to load data and use it
        // var savedData = SaveLoadSystem.LoadAll();
        // Debug.Log(savedData[4].identifier + ": " + savedData[4].value);
        //
        // //Example of how to load a single block
        // var singleBlock = SaveLoadSystem.LoadSpecificBlock("Dex");
        // Debug.Log(singleBlock.value);
        //
        // Debug.Log("Test for saving and loading in one");
        // singleBlock = SaveLoadSystem.LoadSpecificBlock("Age");
        // Debug.Log(singleBlock.value);
        //
        // List<SaveLoadSystem.DataBlock> dataBlocksToSave = new List<SaveLoadSystem.DataBlock>();
        // dataBlocksToSave.Add(new SaveLoadSystem.DataBlock("Age", 30));
        // SaveLoadSystem.Save(dataBlocksToSave.ToArray());
        //
        // singleBlock = SaveLoadSystem.LoadSpecificBlock("Age");
        // Debug.Log(singleBlock.value);
    }

}
