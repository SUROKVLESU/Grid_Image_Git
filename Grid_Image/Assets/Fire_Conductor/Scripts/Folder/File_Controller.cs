using UnityEngine;
using UnityEngine.Events;

public class File_Controller : MonoBehaviour
{
    private DirectoryTransitionController DirectoryTransitionController;
    private FileTransitionController FileTransitionController;
    private FolderButtonController FolderButtonController;
    private FileButtonController FileButtonController;
    private SaveImageButton SaveImageButton;
    //не забудь про очистку ресурсов

    public UnityAction OnClickSaveButtonFile;

    public void Awake()
    {
        DirectoryTransitionController = 
            new DirectoryTransitionController(Plugin.PluginFolder.CallStatic<string>("GetRootDirectory"));
        FileTransitionController = new FileTransitionController();
    }
    public void Start()
    {
        FolderButtonController = gameObject.GetComponent<FolderButtonController>();
        FileButtonController = gameObject.GetComponent<FileButtonController>();
        SaveImageButton = gameObject.GetComponent<SaveImageButton>();
        FolderButtonController.ButtonInitialization();
        FileButtonController.ButtonInitialization();
        SaveImageButton.ButtonInitialization();
        FolderButtonController.Initialization(DirectoryTransitionController.GetSelectedFolder);
        FolderButtonController.UpdateButtons();

        FolderButtonController.OnClickButtonExitingFolder += () =>
        {
            DirectoryTransitionController.ExitingFolder();
            FolderButtonController.Initialization(DirectoryTransitionController.GetSelectedFolder);
            FolderButtonController.UpdateButtons();

            FileTransitionController.ChangingSelectedFolder(DirectoryTransitionController.GetSelectedFolder);
            UpdateSaveButton();
        };
        FolderButtonController.OnClickOpenFolder += () =>
        {
            DirectoryTransitionController.OpenFolder(DirectoryTransitionController.
            GetSelectedFolder[FolderButtonController.GetIndexSelectedFolder]);
            FolderButtonController.Initialization(DirectoryTransitionController.GetSelectedFolder);
            FolderButtonController.UpdateButtons();

            FileTransitionController.ChangingSelectedFolder(DirectoryTransitionController.GetSelectedFolder);
            UpdateSaveButton();
        };

        FileTransitionController.ChangingSelectedGroupFiles += FileButtonController.ChangingSelectedGroupFiles;

        FileTransitionController.ChangingSelectedFolder(DirectoryTransitionController.GetSelectedFolder);
        UpdateSaveButton();
        FileButtonController.NewSelectedTexture += FileTransitionController.SetSelectedTexture;
        FileButtonController.NewSelectedTexture += SaveImageButton.OnImageSaveButton;
        SaveImageButton.OnClickSaveButton += ()=> 
        {
            OnClickSaveButtonFile();
            this.gameObject.SetActive(false);
        };
    }
    private void UpdateSaveButton()
    {
        if (FileTransitionController.GetSelectedGroupFiles.GetCountFile > 0)
        {
            SaveImageButton.OnSaveButton();
        }
        else
        {
            SaveImageButton.OffSaveButton();
        }
    }
    public Texture2D GetTexture()
    {
        return FileTransitionController.GetSelectedTexture;
    }
}
