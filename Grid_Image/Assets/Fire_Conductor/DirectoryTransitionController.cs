using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.WSA;
using System;
using UnityEngine.AdaptivePerformance;
using System.Threading;
using UnityEngine.Events;

public class DirectoryTransitionController
{
    private Folder[] Folders;
    private Folder SelectedFolder;
    private ArrayTransitionNumbersFolder ArrayTransitionNumbersFolder;

    public UnityAction IFinished;

    public Folder GetSelectedFolder => SelectedFolder;
    public DirectoryTransitionController(DriveInfo[] drives)//нужен для создания нулевой папки
    {
        DirectoryInfo[] directoryInfos = new DirectoryInfo[drives.Length];
        for (int i = 0; i < directoryInfos.Length; i++) directoryInfos[i] = drives[i].RootDirectory;
        Folders = new Folder[1] {Folder.NullFolder(directoryInfos) };
        SelectedFolder = Folders[0];
        ArrayTransitionNumbersFolder = new ArrayTransitionNumbersFolder();
        ArrayTransitionNumbersFolder.Add(Folders[0].GetParentFolder.GetUniqueFolderNumber);
    }
    public void ExitingFolder()
    {
        if (ArrayTransitionNumbersFolder.Watch == 0)
        {
            SelectedFolder = Folders[0];
            return;
        }
        ArrayTransitionNumbersFolder.Remove();
        if (ArrayTransitionNumbersFolder.Watch == 0)
        {
            SelectedFolder = Folders[0];
            return;
        }
        for (int i = 1; i < Folders.Length;i++)
        {
            if (Folders[i].GetParentFolder.GetUniqueFolderNumber == ArrayTransitionNumbersFolder.Watch)
                SelectedFolder = Folders[i];
        }
        IFinished();
    }
    public void OpenFolder(FolderPointer folder)
    {
        if (folder.GetBeenHere)
        {
            if (folder.GetUniqueFolderNumber == 0)
            {
                SelectedFolder = Folders[0];
                return;
            }
            for (int i = 1; i < Folders.Length; i++)
            {
                if (Folders[i].GetParentFolder.GetUniqueFolderNumber == folder.GetUniqueFolderNumber)
                    SelectedFolder = Folders[i];
            }
        }
        else
        {
            SelectedFolder = Folder.CreateFolder(folder);
            AddFolder(SelectedFolder);
            ArrayTransitionNumbersFolder.Add(SelectedFolder.GetParentFolder.GetUniqueFolderNumber);
        }
    }
    private void AddFolder(Folder folder)
    {
        Folder[] array = new Folder[Folders.Length + 1];
        for (int i = 0; i < Folders.Length; i++)
        {
            array[i] = Folders[i];
        }
        array[Folders.Length] = folder;
        Folders = array;
    }
}
