# UnitySaveLoadSystem
This is a small and easy to use package created so that you can use a single Player Prefs key to store all of your data in Unity. It works by putting data into a custom struct called DataBlocks and converting each DataBlock into a single string and storing that in the Player Prefs. This makes it super easy for having data carry over sessions on WebGL games. 

You can find the script [HERE](https://github.com/evskii/UnitySaveLoadSystem/blob/main/SaveLoadSystem/Assets/Scripts/SaveLoadSystem.cs), or download the whole project to see it in action (not very exciting)!

### How To Use:
- Store SaveLoadSystem.cs somewhere in your project files and you are good to go.
- Data is stored in DataBlocks using an identifier and a value. Create a DataBlock and then call SaveLoadSystem.Save(DataBlockHere); to save a single data block.
- You can also pass an array of DataBlocks if you want to store more than one at a time. (If you pass in a DataBlock with an identifier that is already in use it overrides the old value. Good for updating values, bad if that is not what you want to do :/).
- You can then call LoadAll(); to get an array of all DataBlocks that are saved, or LoadSpecificBlock(string identifier); to load a single block.
- **Don't attempt to use Load methods before saving for the first time as it returns errors.**

### Usage Rights:
Go for it! Credit me if you want, don't if you dont x

**If you find any bugs, feel free to let me know!**
