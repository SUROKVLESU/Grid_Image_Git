using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class File_Controller : MonoBehaviour
{
    private DirectoryTransitionController DirectoryTransitionController;
    private FileTransitionController FileTransitionController;
    private FolderButtonController FolderButtonController;
    private FileButtonController FileButtonController;
    public static AndroidJavaClass PluginFolder;
    //не забудь про очистку ресурсов


    public void Awake()
    {
        PluginFolder = new AndroidJavaClass("com.example.mylibrarytest.PluginFolder");
        DirectoryTransitionController = 
            new DirectoryTransitionController(PluginFolder.CallStatic<string>("GetRootDirectory"));
        FileTransitionController = new FileTransitionController();
    }
    public void Start()
    {
        FolderButtonController = gameObject.GetComponent<FolderButtonController>();
        FileButtonController = gameObject.GetComponent<FileButtonController>();
        FolderButtonController.ButtonInitialization();
        FileButtonController.ButtonInitialization();
        FolderButtonController.Initialization(DirectoryTransitionController.GetSelectedFolder);
        FolderButtonController.UpdateButtons();

        FolderButtonController.OnClickButtonExitingFolder -= () => { };
        FolderButtonController.OnClickOpenFolder -= () => { };
        FolderButtonController.OnClickButtonExitingFolder += () =>
        {
            DirectoryTransitionController.ExitingFolder();
            FolderButtonController.Initialization(DirectoryTransitionController.GetSelectedFolder);
            FolderButtonController.UpdateButtons();

            FileTransitionController.ChangingSelectedFolder(DirectoryTransitionController.GetSelectedFolder);
        };
        FolderButtonController.OnClickOpenFolder += () =>
        {
            DirectoryTransitionController.OpenFolder(DirectoryTransitionController.
            GetSelectedFolder[FolderButtonController.GetIndexSelectedFolder]);
            FolderButtonController.Initialization(DirectoryTransitionController.GetSelectedFolder);
            FolderButtonController.UpdateButtons();

            FileTransitionController.ChangingSelectedFolder(DirectoryTransitionController.GetSelectedFolder);
        };

        FileTransitionController.ChangingSelectedGroupFiles -= (x) => { };
        FileTransitionController.ChangingSelectedGroupFiles += FileButtonController.ChangingSelectedGroupFiles;

        FileTransitionController.ChangingSelectedFolder(DirectoryTransitionController.GetSelectedFolder);

    }
}
