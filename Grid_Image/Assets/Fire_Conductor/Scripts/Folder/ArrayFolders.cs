
public class ArrayFolders
{
    private FolderPointer[] ArrayFoldersDirectory;
    private FolderPointer ParentFolder;//Родительская папка
    private int CountFolder;


    public int GetCountFolder => CountFolder;
    public FolderPointer GetParentFolder => ParentFolder;
    private bool ThereAreFolders => CountFolder > 0;//папки есть

    public FolderPointer this[int index]
    {
        get
        { 
            if(ThereAreFolders && index <= (CountFolder-1) && index >= 0) 
                return ArrayFoldersDirectory[index];
            else return null;
        }
    }
    public ArrayFolders(FolderPointer folderPointer)
    {
        string[] ArrayGetDirectories =
            Plugin.PluginFolder.CallStatic<string[]>("GetDirectories", folderPointer.GetDirectoryInfo);
        ArrayFoldersDirectory = new FolderPointer[ArrayGetDirectories.Length];
        for (int i = 0; i < ArrayGetDirectories.Length; i++)
        {
            ArrayFoldersDirectory[i] = new FolderPointer(ArrayGetDirectories[i]);
        }
        CountFolder = ArrayFoldersDirectory.Length;
        ParentFolder = folderPointer;
        ParentFolder.SetBeenHereAndUniqueFolderNumber();
    }
    public ArrayFolders(string[] directories)//используется для создание несуществующей папки
                                                    //с дисками внутри
    {
        ArrayFoldersDirectory = new FolderPointer[directories.Length];
        for (int i = 0; i < directories.Length; i++)
        {
            ArrayFoldersDirectory[i] = new FolderPointer(directories[i]);
        }
        CountFolder = ArrayFoldersDirectory.Length;
        ParentFolder = new FolderPointer();
    }
}
