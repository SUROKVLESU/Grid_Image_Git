using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.WSA;
using System;
using UnityEngine.AdaptivePerformance;
using System.Threading;

public class DirectoryTransitionController : MonoBehaviour 
{
    private Folder[] folders;
    private Folder SelectedFolder;
    //private Folder ExitFolder;
    


    public DirectoryTransitionController(DriveInfo[] drives)
    {
        DirectoryInfo[] directoryInfos = new DirectoryInfo[drives.Length];
        for (int i = 0; i < directoryInfos.Length; i++) directoryInfos[i] = drives[i].RootDirectory;
        folders = new Folder[1] {Folder.NullFolder(directoryInfos) };

    }
    public void OpenFolder(DirectoryInfo directory)
    {
        Folder[] folders = new Folder[this.folders.Length+1];
        for (int i = 0; i < folders.Length; i++) 
        {
            folders[i]=this.folders[i];
        }
        folders[this.folders.Length] = SelectedFolder;
        //ExitFolder = SelectedFolder;
        this.folders = folders;
        SelectedFolder = Folder.CreateFolder(directory);
    }
    public void CloseFolder(DirectoryInfo directory)
    {
        SelectedFolder = this.SearchExitFolder();
    }
    public Folder SearchExitFolder()
    {
        if(SelectedFolder.GetUniqueFolderNumber == 0) return this.folders[0];
        int DistanceIndex = 1;
        string DirectoryInfoFolderName = SelectedFolder.DirectoryInfoFolder.Parent.FullName;
        for (int i = 0; i < this.folders.Length;i++)
        {
            if ((SelectedFolder.GetUniqueFolderNumber
               - this.folders[i].GetUniqueFolderNumber) == DistanceIndex&&
               this.folders[i].GetUniqueFolderNumber!=0)
            {
                if (DirectoryInfoFolderName.Equals(this.folders[i].DirectoryInfoFolder.FullName))
                { return this.folders[i]; }
                else
                {
                    DistanceIndex++;
                    i = 0;
                    if (DistanceIndex == SelectedFolder.GetUniqueFolderNumber)
                    { 
                    return this.folders[0];
                    }
                }
            }
        }
        return this.folders[0];

    }
    public Folder SearchNextFolder(DirectoryInfo directory)
    {

        return Folder.CreateFolder(directory);
    }
}
