using UnityEngine.Events;

public class FileTransitionController
{
    private GroupFiles[] ArrGroupFiles;
    private GroupFiles SelectedGroupFiles;

    public UnityAction<GroupFiles> ChangingSelectedGroupFiles = new UnityAction<GroupFiles>((x) => { });

    public void ChangingSelectedFolder(Folder folder)
    {
        if(IsGroupFile(folder.GetParentFolder.GetUniqueFolderNumber))
        {
            SelectedGroupFiles = GetGroupFiles(folder.GetParentFolder.GetUniqueFolderNumber);
            ChangingSelectedGroupFiles(SelectedGroupFiles);
        }
        else
        {
            SelectedGroupFiles = new GroupFiles(folder);
            ChangingSelectedGroupFiles(SelectedGroupFiles);
            AddGroupFile(SelectedGroupFiles);
        }
    }
    private void AddGroupFile(GroupFiles groupFiles)
    {
        if(ArrGroupFiles != null)
        {
            GroupFiles[] Arr = new GroupFiles[ArrGroupFiles.Length + 1];
            for (int i = 0; i < ArrGroupFiles.Length; i++)
            {
                Arr[i] = ArrGroupFiles[i];
            }
            Arr[ArrGroupFiles.Length] = groupFiles;
            ArrGroupFiles = Arr;
        }
        else
        {
            ArrGroupFiles = new GroupFiles[] {groupFiles};
        }
    }
    private bool IsGroupFile(int UniqueGroupFilesNumber)
    {
        if (ArrGroupFiles == null || ArrGroupFiles.Length > 0) { return false; }
        else
        { 
            for (int i = 0; i < ArrGroupFiles.Length; i++)
            {
                if(ArrGroupFiles[i].GetUniqueGroupFilesNumber == UniqueGroupFilesNumber) return true;
            }
            return false;
        }
    }
    private GroupFiles GetGroupFiles(int UniqueGroupFilesNumber)
    {
        for (int i = 0; i < ArrGroupFiles.Length; i++)
        {
            if (ArrGroupFiles[i].GetUniqueGroupFilesNumber == UniqueGroupFilesNumber) return ArrGroupFiles[i];
        }
        return null;
    }
}
