using System;
using System.Collections;
using System.Collections.Generic;
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
    
    //We call this to save data. We can pass an array (any size) and it will override old values
    //and append new values
    public static void Save(DataBlock[] dataBlocksToSave) {
        if (dataBlocksToSave.Length == 0) {
            Debug.LogError("No DataBlock has been sent to save");
            return;
        } else {
            string saveDataString = PlayerPrefs.GetString(ppKeyName);
            var newString = "";
            var oldString = "";
            foreach (DataBlock block in dataBlocksToSave) {
                if (saveDataString.Contains(block.identifier)) {
                    var splitDataString = saveDataString.Split(':');
                    foreach (var splitBlock in splitDataString) {
                        if (splitBlock != "") {
                            if (splitBlock.Split(',')[0] == block.identifier) {
                                oldString += block.identifier + "," + block.value + ":";
                            }
                        } 
                    }
                } else {
                    newString += block.identifier + "," + block.value + ":";
                }
            }
            
            string toSave = oldString + newString;
            PlayerPrefs.SetString(ppKeyName, toSave);
            Debug.Log("DataSaved: " + toSave);
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
                if (serializedBlock != "") {
                    var splitBlock = serializedBlock.Split(',');
                    DataBlock deserializedBlock = new DataBlock(splitBlock[0], Int32.Parse(splitBlock[1]));
                    dataBlocksToLoad.Add(deserializedBlock);
                }
            }
        
            return dataBlocksToLoad.ToArray();
        }
    }

    //Used to load a specific data block
    public static DataBlock LoadSpecificBlock(string identifier) {
        if (!PlayerPrefs.HasKey(ppKeyName)) {
            Debug.LogError("Trying to load " + identifier + " from: " + ppKeyName + " however this key does not exist!");
            return new DataBlock("INVALID", 0);
        } else {
            string serializedData = PlayerPrefs.GetString(ppKeyName);
            var serializedBlocks = serializedData.Split(':');

            foreach (var serializedBlock in serializedBlocks) {
                var temp = serializedBlock.Split(',');
                if (temp[0] == identifier) {
                    return new DataBlock(temp[0], Int32.Parse(temp[1]));
                }
            }
            Debug.LogError("Trying to load data for " + identifier + " however  it does not exist inside of " + ppKeyName);
            return new DataBlock("INVALID", 0);
        }
    }
}
