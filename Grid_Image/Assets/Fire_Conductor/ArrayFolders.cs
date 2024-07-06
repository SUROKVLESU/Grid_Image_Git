using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Windows;

public class ArrayFolders
{
    private FolderPointer[] ArrayFoldersDirectory;
    private FolderPointer ParentFolder;//–одительска€ папка
    private int CountFolder;


    public int GetCountFolder => CountFolder;
    public FolderPointer GetParentFolder => ParentFolder;
    public bool ThereAreFolders => CountFolder != 0;//папки есть

    public FolderPointer this[int index]
    {
        get
        { 
            if(ThereAreFolders && index <= (CountFolder-1) && index >= 0) 
                return ArrayFoldersDirectory[index];
            else return null;
        }
    }
    public ArrayFolders(FolderPointer folderPointer)
    {
        DirectoryInfo[] ArrayGetDirectories = folderPointer.GetDirectoryInfo.GetDirectories();
        ArrayFoldersDirectory = new FolderPointer[ArrayGetDirectories.Length];
        for (int i = 0; i < ArrayGetDirectories.Length; i++)
        {
            ArrayFoldersDirectory[i] = new FolderPointer(ArrayGetDirectories[i]);
        }
        CountFolder = ArrayFoldersDirectory.Length;
        ParentFolder = folderPointer;
        ParentFolder.SetBeenHereAndUniqueFolderNumber();//этот номер может и не тут надо писать
    }
    /*public ArrayFolders(DirectoryInfo directory)
    {
        DirectoryInfo[] ArrayGetDirectories = directory.GetDirectories();
        ArrayFoldersDirectory = new FolderPointer[ArrayGetDirectories.Length];
        for (int i = 0; i < ArrayGetDirectories.Length; i++)
        {
            ArrayFoldersDirectory[i] = new FolderPointer(ArrayGetDirectories[i]);
        }
        CountFolder = ArrayFoldersDirectory.Length;
        ParentFolder = new FolderPointer(directory);
        ParentFolder.SetUniqueFolderNumber();//этот номер может и не тут надо писать
        ParentFolder.SetBeenHere();
    }*/
    public ArrayFolders(DirectoryInfo[] directories)//используетс€ дл€ создание несуществующей папки
                                                    //с дисками внутри
    {
        ArrayFoldersDirectory = new FolderPointer[directories.Length];
        for (int i = 0; i < directories.Length; i++)
        {
            ArrayFoldersDirectory[i] = new FolderPointer(directories[i]);
        }
        CountFolder = ArrayFoldersDirectory.Length;
        ParentFolder = new FolderPointer();
    }
}
