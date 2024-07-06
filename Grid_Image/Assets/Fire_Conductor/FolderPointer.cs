using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FolderPointer
{
    private DirectoryInfo DirectoryInfo;
    private bool BeenHere;//Был тут
    private int UniqueFolderNumber;//Номер папки
    private static int FollowingUniqueFolderNumber = 0;//Следкющий номер папки


    public int GetUniqueFolderNumber => this.UniqueFolderNumber;
    public DirectoryInfo GetDirectoryInfo => this.DirectoryInfo;
    public bool GetBeenHere => this.BeenHere;
    public void SetBeenHereAndUniqueFolderNumber() 
    { 
        BeenHere = true;
        UniqueFolderNumber = FollowingUniqueFolderNumber++;//тут может быть ошибка
    }
    public FolderPointer()//используется для создания нулевой папки
    {
        this.DirectoryInfo = null;
        UniqueFolderNumber = FollowingUniqueFolderNumber++;//возможно ошибка
        BeenHere = true;
    }
    public FolderPointer(DirectoryInfo directory)
    {
        DirectoryInfo = directory;
        BeenHere = false;
    }
}
