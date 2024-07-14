
public class DirectoryTransitionController
{
    private Folder[] Folders;
    private Folder SelectedFolder;
    private ArrayTransitionNumbersFolder ArrayTransitionNumbersFolder;

    public Folder GetSelectedFolder => SelectedFolder;
    public DirectoryTransitionController(string drives)//нужен для создания нулевой папки
    {
        string[] directoryInfos =
            File_Controller.PluginFolder.CallStatic<string[]>("GetDirectories", drives);
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
            {
                SelectedFolder = Folders[i];
            }

        }
    }
    public void OpenFolder(FolderPointer folder)
    {
        if (folder.GetBeenHere)
        {
            for (int i = 1; i < Folders.Length; i++)
            {
                if (Folders[i].GetParentFolder.GetUniqueFolderNumber == folder.GetUniqueFolderNumber)
                {
                    SelectedFolder = Folders[i];
                    ArrayTransitionNumbersFolder.Add(SelectedFolder.GetParentFolder.GetUniqueFolderNumber);
                }
            }
        }
        else
        {
            SelectedFolder = Folder.CreateFolder(folder);
            AddFolder(SelectedFolder);
            ArrayTransitionNumbersFolder.Add(SelectedFolder.GetParentFolder.GetUniqueFolderNumber);
        }
    }
    protected void AddFolder(Folder folder)
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
