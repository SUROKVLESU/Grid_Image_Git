using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Threading;

public class File_Controller : MonoBehaviour
{
    private DriveInfo[] drives;//массив дисков
    private DirectoryInfo DirectoryInfo;
    private ArrayFolders ArrayFolders;//массив каталогов
    private DirectoryTransitionController directoryTransitionController;


    private void Awake()
    {
        drives = DriveInfo.GetDrives();//получили массив дисков
        directoryTransitionController = new DirectoryTransitionController(drives);

        DirectoryInfo = drives[0].RootDirectory;
        ArrayFolders = new ArrayFolders(DirectoryInfo);
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    public void Update()
    {
        //MyDebag();
    }
    private void MyDebag()
    {
        //Debug.Log(ArrayFolders[0].Name+"("+ ArrayFolders[0].Root.Name+")");
        //Thread.Sleep(1000);
    }
}
