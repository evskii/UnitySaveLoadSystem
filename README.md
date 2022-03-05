# UnitySaveLoadSystem
A save/load system for Unity utilizing playerprefs so you can have persistent data on WebGL.

This is a small and easy to use package created so that you can use a single Player Prefs key to store all of your data in Unity. It works by putting data into a custom struct called DataBlocks and converting each DataBlock into a single string and storing that in the Player Prefs. This makes it super easy for having data carry over sessions on WebGL games. 

You can store new DataBlocks or if you pass in a DataBlock with the same identifier string it will overwrite the old value stored in the key. You can store a an array of DataBlocks at once or store a single block if needed. You can also load all data at once or load a single DataBlock when needed. 

The package is stored in a static class called SaveLoadSystem.cs so you can call it's methods from wherever in runtime.
