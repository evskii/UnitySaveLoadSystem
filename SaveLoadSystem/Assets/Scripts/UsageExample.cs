using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsageExample : MonoBehaviour
{
    void Start() {
        
         //Example of saving several blocks of data
         List<SaveLoadSystem.DataBlock> dataBlocksToSave = new List<SaveLoadSystem.DataBlock>(); //Create the list to store the data in
         dataBlocksToSave.Add(new SaveLoadSystem.DataBlock("Age", 28));
         dataBlocksToSave.Add(new SaveLoadSystem.DataBlock("Strength", 18));
         dataBlocksToSave.Add(new SaveLoadSystem.DataBlock("Dex", 36));
         dataBlocksToSave.Add(new SaveLoadSystem.DataBlock("Money", 3000));
         dataBlocksToSave.Add(new SaveLoadSystem.DataBlock("Souls", 83));
         SaveLoadSystem.Save(dataBlocksToSave.ToArray()); //Call the Save() method and convert your list into an array
        
        //Example of saving a single block of data
         SaveLoadSystem.Save(new SaveLoadSystem.DataBlock("Souls", 68));
        
         // Example of how to load data and use it
         var savedData = SaveLoadSystem.LoadAll();
         Debug.Log(savedData[4].identifier + ": " + savedData[4].value);
        
        //Example of how to load a single block
         var singleBlock = SaveLoadSystem.LoadSpecificBlock("Souls");
         Debug.Log(singleBlock.value);
        
    }

}
