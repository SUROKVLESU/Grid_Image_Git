using System.IO;

public class Folder
{

    private ArrayFolders ArrayFolders;
    public FolderPointer GetParentFolder => ArrayFolders.GetParentFolder;
    public FolderPointer this[int index] => ArrayFolders[index];
    public int GetCountFolder => ArrayFolders.GetCountFolder;   

    public static Folder CreateFolder(FolderPointer parentFolder)
    {
        return new Folder()
        {
        ArrayFolders = new ArrayFolders(parentFolder)
        };   
    }
    public static Folder NullFolder(DirectoryInfo[] directories)
    {
        return new Folder()
        {
            ArrayFolders = new ArrayFolders(directories)
        };
    }
}
