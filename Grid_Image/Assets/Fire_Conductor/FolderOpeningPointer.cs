using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderOpeningPointer
{
    //private bool BeenHere = false;//��� ���
    private readonly int UniqueFolderNumber;//����� �����
    private static int FollowingUniqueFolderNumber = 0;//��������� ����� �����


    public int GetUniqueFolderNumber
    {
    get{ return this.UniqueFolderNumber; }
    }
    public FolderOpeningPointer()
    {
        UniqueFolderNumber = FollowingUniqueFolderNumber;
        FollowingUniqueFolderNumber++;
        //BeenHere = true;
    }
}
