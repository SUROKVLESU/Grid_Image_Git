using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupFiles : MonoBehaviour
{
    private string[] Files;
    private int UniqueGroupFilesNumber;
    private int CountFile;

    private bool ThereAreFile => CountFile > 0;
    public int GetUniqueGroupFilesNumber => UniqueGroupFilesNumber;
    public int GetCountFile => CountFile;
    public string this[int index]
    {  
        get 
        {
            if (ThereAreFile && index <= (CountFile - 1) && index >= 0)
                return Files[index];
            else return null;
        } 
    }

    public GroupFiles(Folder Directory)
    {
        UniqueGroupFilesNumber = Directory.GetParentFolder.GetUniqueFolderNumber;
        if(Directory.GetParentFolder.GetDirectoryInfo!=null)
        {
            Files =
            File_Controller.PluginFolder.CallStatic<string[]>
                ("GetFiles", Directory.GetParentFolder.GetDirectoryInfo);
            CountFile = Files.Length;
        }
        else
        {
            Files = new string[0];
            CountFile = 0;
        }
    }
}
