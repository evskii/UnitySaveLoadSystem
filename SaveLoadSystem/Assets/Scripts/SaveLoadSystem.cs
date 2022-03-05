using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            string savedData = PlayerPrefs.GetString(ppKeyName); //Get our currently saved string of data
            var chunks = savedData.Split(':').ToList(); //Split that up into datablocks as string chunks
            foreach (DataBlock block in dataBlocksToSave) { //Loop through the blocks we have sent to this method
                if (!string.IsNullOrEmpty(block.identifier)) { //Using Split() can create an empty string so we ignore those
                    bool newData = true; //This is a switch to see if it was a new datablock or one that we are just editing
                    for (int i = 0; i < chunks.Count; i++) { //Loop through the string chunks
                        if (chunks[i].Split(',')[0] == block.identifier) { //If we have find a chunk that is the same id as the block we are saving
                            newData = false; //Switch the switch
                            chunks[i] = block.identifier + "," + block.value; //Modify the chunk so that it uses the new value
                            break; //Break the loop
                        }
                    }
                    if (newData) { //If the loop gets here and the switch hasnt been triggered then we know its new data
                        chunks.Add(block.identifier + "," + block.value); //Add to the end of our list of chunks
                    }
                }
            }
            string newSaveData = ""; //Create a new empty string to serialize our chunks into
            foreach (string blockString in chunks) { //Loop through our chunks
                if (!string.IsNullOrEmpty(blockString)) { //One last check for empty strings
                    newSaveData += blockString + ":"; //Merge each chunk into the single string
                }
            }
            Debug.Log("NewSaveData: " + newSaveData); 
            PlayerPrefs.SetString(ppKeyName, newSaveData); //Save our data to the playerprefs key
        }
    }

    //Used to load all data blocks as an array
    public static DataBlock[] LoadAll() {
        if (!PlayerPrefs.HasKey(ppKeyName)) { //If we try to load the data but the key doesn't exist run an error
            Debug.LogError("Trying to load data from: " + ppKeyName + " however this key does not exist!");
            return null;
        } else {
            List<DataBlock> dataBlocksToLoad = new List<DataBlock>(); //Empty list that we will fill with the data blocks we are loading
            string serializedData = PlayerPrefs.GetString(ppKeyName); //Get our saved data
            var serializedBlocks = serializedData.Split(':'); //Split it up into chunks
            foreach (string serializedBlock in serializedBlocks) { //Loop through each serialized block
                if (serializedBlock != "") { //Ignore blank shit
                    var splitBlock = serializedBlock.Split(','); //Split our block into [0] ID and [1] Value using the , as a delimiter
                    DataBlock deserializedBlock = new DataBlock(splitBlock[0], Int32.Parse(splitBlock[1]));  //Create a new dataBlock (class) instance
                    dataBlocksToLoad.Add(deserializedBlock); //Add to our list
                }
            }
        
            return dataBlocksToLoad.ToArray(); //Return the list as an array
        }
    }

    //Used to load a specific data block
    public static DataBlock LoadSpecificBlock(string identifier) {
        if (!PlayerPrefs.HasKey(ppKeyName)) {
            Debug.LogError("Trying to load " + identifier + " from: " + ppKeyName + " however this key does not exist!");
            return new DataBlock("INVALID", 0);
        } else {
            string serializedData = PlayerPrefs.GetString(ppKeyName); //Load our data from player prefs
            var serializedBlocks = serializedData.Split(':'); //Split the string up into blocks
            foreach (var serializedBlock in serializedBlocks) { //Loop through the blocks
                var temp = serializedBlock.Split(','); //split the block we are looking at
                if (temp[0] == identifier) { //Check if the id we passed is equal to one of the blocks
                    return new DataBlock(temp[0], Int32.Parse(temp[1])); //return a new dataBlock instance for that id if we find it
                }
            }
            Debug.LogError("Trying to load data for " + identifier + " however  it does not exist inside of " + ppKeyName); //Return an error if we don't find the data
            return new DataBlock("INVALID", 0);
        }
    }
}
