using System.IO;

public class FolderPointer
{
    private DirectoryInfo DirectoryInfo;
    private bool BeenHere;//Был тут
    private int UniqueFolderNumber = -1;//Номер папки
    private static int FollowingUniqueFolderNumber = 0;//Следкющий номер папки


    public int GetUniqueFolderNumber => this.UniqueFolderNumber;
    public DirectoryInfo GetDirectoryInfo => this.DirectoryInfo;
    public bool GetBeenHere => this.BeenHere;
    public void SetBeenHereAndUniqueFolderNumber() 
    { 
        BeenHere = true;
        UniqueFolderNumber = FollowingUniqueFolderNumber++;
    }
    public FolderPointer()//используется для создания нулевой папки
    {
        this.DirectoryInfo = null;
        UniqueFolderNumber = FollowingUniqueFolderNumber++;
        BeenHere = true;
    }
    public FolderPointer(DirectoryInfo directory)
    {
        DirectoryInfo = directory;
        BeenHere = false;
    }
}
