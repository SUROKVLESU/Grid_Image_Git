using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Windows;

public class Folder
{

    private ArrayFolders ArrayFolders;
    public FolderPointer GetParentFolder => ArrayFolders.GetParentFolder;
    public FolderPointer this[int index] => ArrayFolders[index];
    public int GetCountFolder => ArrayFolders.GetCountFolder;   
    public static bool operator ==(Folder left, Folder right)
    {
        return left.GetParentFolder.GetUniqueFolderNumber == right.GetParentFolder.GetUniqueFolderNumber;
    }
    public static bool operator !=(Folder left, Folder right)
    {
        return !(left == right);
    }
    public static bool operator >(Folder left, Folder right)
    {
        return left.GetParentFolder.GetUniqueFolderNumber > right.GetParentFolder.GetUniqueFolderNumber;
    }
    public static bool operator <(Folder left, Folder right)
    {
        return left.GetParentFolder.GetUniqueFolderNumber < right.GetParentFolder.GetUniqueFolderNumber;
    }
    public static bool operator >=(Folder left, Folder right)
    {
        return left.GetParentFolder.GetUniqueFolderNumber >= right.GetParentFolder.GetUniqueFolderNumber;
    }
    public static bool operator <=(Folder left, Folder right)
    {
        return left.GetParentFolder.GetUniqueFolderNumber <= right.GetParentFolder.GetUniqueFolderNumber;
    }

    public static Folder CreateFolder(FolderPointer parentFolder)
    {
        return new Folder()
        {
        ArrayFolders = new ArrayFolders(parentFolder)
        };   
    }
    /*public static Folder CreateFolder(DirectoryInfo directory)
    {
        return new Folder()
        {
            ArrayFolders = new ArrayFolders(directory)
        };
    }*/
    public static Folder NullFolder(DirectoryInfo[] directories)
    {
        return new Folder()
        {
            ArrayFolders = new ArrayFolders(directories)
        };
    }
}
