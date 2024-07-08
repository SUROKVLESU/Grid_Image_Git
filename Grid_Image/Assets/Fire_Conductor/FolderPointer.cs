using System.IO;

public class FolderPointer
{
    private DirectoryInfo DirectoryInfo;
    private bool BeenHere;//��� ���
    private int UniqueFolderNumber = -1;//����� �����
    private static int FollowingUniqueFolderNumber = 0;//��������� ����� �����


    public int GetUniqueFolderNumber => this.UniqueFolderNumber;
    public DirectoryInfo GetDirectoryInfo => this.DirectoryInfo;
    public bool GetBeenHere => this.BeenHere;
    public void SetBeenHereAndUniqueFolderNumber() 
    { 
        BeenHere = true;
        UniqueFolderNumber = FollowingUniqueFolderNumber++;
    }
    public FolderPointer()//������������ ��� �������� ������� �����
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
