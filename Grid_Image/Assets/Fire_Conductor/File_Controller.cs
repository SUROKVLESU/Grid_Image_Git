using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Threading;
using TMPro;

public class File_Controller : MonoBehaviour
{
    private DirectoryTransitionController DirectoryTransitionController;
    private FolderButtonController FolderButtonController;

    public Text TextMeshPro;

    public void Awake()
    {
        DirectoryTransitionController = new DirectoryTransitionController(DriveInfo.GetDrives());
    }
    public void Start()
    {
        FolderButtonController = gameObject.GetComponent<FolderButtonController>();
        FolderButtonController.ButtonInitialization();
        FolderButtonController.Initialization(DirectoryTransitionController.GetSelectedFolder);
        FolderButtonController.UpdateButtons();

        FolderButtonController.OnClickButtonExitingFolder -= () => { };
        FolderButtonController.OnClickOpenFolder -= () => { };
        FolderButtonController.OnClickButtonExitingFolder += () =>
        {
            DirectoryTransitionController.ExitingFolder();
            FolderButtonController.Initialization(DirectoryTransitionController.GetSelectedFolder);
            DirectoryTransitionController.IFinished();
        };
        FolderButtonController.OnClickOpenFolder += () =>
        {
            DirectoryTransitionController.OpenFolder(DirectoryTransitionController.
            GetSelectedFolder[FolderButtonController.GetIndexSelectedFolder]);
            FolderButtonController.Initialization(DirectoryTransitionController.GetSelectedFolder);
            DirectoryTransitionController.IFinished();
        };
        DirectoryTransitionController.IFinished -= () => { };
        DirectoryTransitionController.IFinished += () => FolderButtonController.UpdateButtons();
    }
}
