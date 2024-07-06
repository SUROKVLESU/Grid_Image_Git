using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderOpeningPointer
{
    //private bool BeenHere = false;//Был тут
    private readonly int UniqueFolderNumber;//Номер папки
    private static int FollowingUniqueFolderNumber = 0;//Следкющий номер папки


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
