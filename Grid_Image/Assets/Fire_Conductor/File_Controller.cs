using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Threading;

public class File_Controller : MonoBehaviour
{
    private DirectoryTransitionController DirectoryTransitionController;


    private void Awake()
    {
        DirectoryTransitionController = new DirectoryTransitionController(DriveInfo.GetDrives());
    }
}
