using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Unity.VisualScripting;

using UnityEngine;

public static class SaveLoadSystem
{
    //This is the format we store our data as. Identifier = Name to identify data by (e.g Highscore, Strength, Age)
    //value is the value of what we are saving. Default is an integer but you can change to be whatever.
    public struct DataBlock {
        public DataBlock(string id, int val) {
            identifier = id;
            value = val;
        }
        public string identifier;
        public int value;
    }

    public static string ppKeyName = "SaveData"; //This is the name of the key that we are saving the data to in player prefs

    [RuntimeInitializeOnLoadMethod]
    public static void InitializePlayerPrefs() {
        if (!PlayerPrefs.HasKey(ppKeyName)) { //If our data string doesnt exists yet, then make a blank
            PlayerPrefs.SetString(ppKeyName, "");
        }
        Debug.Log("PlayerPrefs have been initialized");
    }
    
    public static void Save(DataBlock[] dataBlocksToSave) {
        if (dataBlocksToSave.Length == 0) {
            Debug.LogError("No DataBlock has been sent to save");
            return;
        } else {
            string saveDataString = ""; 
            foreach (DataBlock block in dataBlocksToSave) {
                string currentSavedData = PlayerPrefs.GetString(ppKeyName);
                //Check if we have a datablock already saved for this block
                if (currentSavedData.Contains(block.identifier)) {
                    //Replace the current block value with our new one
                    var currentSerializedBlocks = currentSavedData.Split(':').ToList();
                    foreach (string serializedBlock in currentSerializedBlocks) {
                        if (serializedBlock.Split(',')[0] == block.identifier) {
                            currentSerializedBlocks.Remove(serializedBlock);
                            currentSerializedBlocks.Add(block.identifier + "," + block.value.ToString() + ":");
                        }
                        saveDataString += serializedBlock;
                    }
                } else {
                    string temp = block.identifier + "," + block.value.ToString() + ":";
                    saveDataString += temp;
                }
            }
            PlayerPrefs.SetString(ppKeyName, saveDataString);
            Debug.Log("DataSaved: " + saveDataString);
        }
    }

    //Used to load all data blocks as an array
    public static DataBlock[] LoadAll() {
        if (!PlayerPrefs.HasKey(ppKeyName)) {
            Debug.LogError("Trying to load data from: " + ppKeyName + " however this key does not exist!");
            return null;
        } else {
            List<DataBlock> dataBlocksToLoad = new List<DataBlock>();

            string serializedData = PlayerPrefs.GetString(ppKeyName);
            var serializedBlocks = serializedData.Split(':');
            foreach (string serializedBlock in serializedBlocks) {
                var splitBlock = serializedBlock.Split(',');
                DataBlock deserializedBlock = new DataBlock(splitBlock[0], Int32.Parse(splitBlock[1]));
                dataBlocksToLoad.Add(deserializedBlock);
            }
        
            return dataBlocksToLoad.ToArray();
        }
    }

    //Used to load a specific data block
    public static void LoadSpecificBlock(string identifier) {
        
    }
}
