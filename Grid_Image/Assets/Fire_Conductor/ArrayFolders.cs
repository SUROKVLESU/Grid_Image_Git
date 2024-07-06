using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Windows;

public class ArrayFolders
{
    private DirectoryInfo[] ArrayFoldersDirectory;
    private bool[] ThereIsFolder;
    private DirectoryInfo ParentFolder;//������������ �����
    private int IndexLastFileShown = -1;
    private int CountFolder;
    //private bool DirectoryEmpty = true;//������� ����





    public void SetThereIsFolder(int index)
    {
        ThereIsFolder[index] = true;
    }
    public bool GetThereIsFolder(int index)
    {
        return ThereIsFolder[index];
    }
    public DirectoryInfo GetParentFolder
    {
        get {  return ParentFolder; }
            
    }
    public bool ThereAreFolders()//����� ����
    {
        if (CountFolder == 0) return false;
        else return true;
    }
    public DirectoryInfo GetNextFolder()//���������� ��������� �����
    {
        if (CountFolder > (IndexLastFileShown+1)) return ArrayFoldersDirectory[IndexLastFileShown+1];
        else if(CountFolder!=0) return ArrayFoldersDirectory[0];
        return null;
    }
    public DirectoryInfo GetPrevFolder()//���������� ���������� �����
    {
        if (0 >= (IndexLastFileShown - 1)) return ArrayFoldersDirectory[IndexLastFileShown - 1];
        else if (CountFolder != 0) return ArrayFoldersDirectory[CountFolder-1];
        return null;
    }

    public DirectoryInfo this[int index]
    {
        get
        { 
            //IndexLastFileShown = index;
            if(ThereAreFolders() && index <= (CountFolder-1) && index >= 0) 
                return ArrayFoldersDirectory[index];
            else return null;
        }
    }
    public ArrayFolders(DirectoryInfo directory)
    {
        ArrayFoldersDirectory = directory.GetDirectories();
        CountFolder = ArrayFoldersDirectory.Length;
        ParentFolder = directory;
        ThereIsFolder = new bool[CountFolder];
    }
    public ArrayFolders(DirectoryInfo[] directories)
    {
        ArrayFoldersDirectory = directories;
        CountFolder = ArrayFoldersDirectory.Length;
        ThereIsFolder = new bool[CountFolder];
        ParentFolder = null;
    }
}
