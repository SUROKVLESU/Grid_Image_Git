using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Windows;

public class Folder
{
    private FolderOpeningPointer Pointer;
    private ArrayFolders ChildFolders;
    
    public DirectoryInfo DirectoryInfoFolder 
    {
        get { return ChildFolders.GetParentFolder; }
    }
    public int GetUniqueFolderNumber
    {
        get { return Pointer.GetUniqueFolderNumber; }
    }
    /*public FolderOpeningPointer FolderOpeningPointer
    {
        get { return this.Pointer; }
    } */
    public static bool operator ==(Folder left, Folder right)
    {
        return left.GetUniqueFolderNumber == right.GetUniqueFolderNumber;
    }
    public static bool operator !=(Folder left, Folder right)
    {
        return !(left == right);
    }
    public static bool operator >(Folder left, Folder right)
    {
        return left.GetUniqueFolderNumber > right.GetUniqueFolderNumber;
    }
    public static bool operator <(Folder left, Folder right)
    {
        return left.GetUniqueFolderNumber < right.GetUniqueFolderNumber;
    }
    public static bool operator >=(Folder left, Folder right)
    {
        return left.GetUniqueFolderNumber >= right.GetUniqueFolderNumber;
    }
    public static bool operator <=(Folder left, Folder right)
    {
        return left.GetUniqueFolderNumber <= right.GetUniqueFolderNumber;
    }

    public static Folder CreateDriveFolder(DriveInfo drive)
    {
        return new Folder()
        {
            Pointer = new FolderOpeningPointer(),
            ChildFolders= new ArrayFolders(drive.RootDirectory)
        };
    }
    public static Folder CreateFolder(DirectoryInfo directory)
    {
        return new Folder()
        {
            Pointer = new FolderOpeningPointer(),
            ChildFolders = new ArrayFolders(directory)
        };
    }
    public static Folder NullFolder(DirectoryInfo[] directories)
    {
        return new Folder()
        {
            Pointer = new FolderOpeningPointer() ,
            ChildFolders = new ArrayFolders(directories)
        };
    }
    public DirectoryInfo this[int index]
    {
        get
        {
            return ChildFolders[index];
        }
    }
}
