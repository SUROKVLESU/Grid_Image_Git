using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class File_Controller : MonoBehaviour
{
    private DirectoryTransitionController DirectoryTransitionController;
    private FolderButtonController FolderButtonController;
    public static AndroidJavaClass PluginFolder;
    //не забудь про очистку ресурсов


    public void Awake()
    {
        PluginFolder = new AndroidJavaClass("com.example.mylibrarytest.PluginFolder");
        /*string str = PluginFolder.CallStatic<string>("GetRootDirectory");
        PluginFolder.CallStatic("Print",str);*/
        DirectoryTransitionController = 
            new DirectoryTransitionController(PluginFolder.CallStatic<string>("GetRootDirectory"));
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
