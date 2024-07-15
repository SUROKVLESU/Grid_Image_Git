using System.IO;
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
            Files = Sort
            (File_Controller.PluginFolder.CallStatic<string[]>
                ("GetFiles", Directory.GetParentFolder.GetDirectoryInfo));
            CountFile = Files.Length;
        }
        else
        {
            Files = new string[0];
            CountFile = 0;
        }
    }
    private bool IsImage(string path)
    {
        string ext = Path.GetExtension(path);
        if (ext.Equals(".png")) { return true; };
        if (ext.Equals(".jpeg")) { return true; };
        if (ext.Equals(".jpg")) { return true; };
        return false;
    }
    private string[] Sort(string[] files)
    {
        int countImage = 0;
        foreach (string file in files)
        {
            if (IsImage(file)) { countImage++; }
        }
        string[] sort = new string[countImage];
        int index = countImage-1;
        foreach (var item in files)
        {
            if (IsImage(item)) 
            { 
                sort[index] = item;
                index--;
            }
        }
        return sort;
    }
}
