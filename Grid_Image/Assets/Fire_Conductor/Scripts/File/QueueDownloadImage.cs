using System;
using System.Collections;
using Unity.Burst.Intrinsics;
using UnityEngine;
internal class QueueDownloadImage : MonoBehaviour
{
    private Action[] ArrDownloadImage;
    private bool IsLaunchPossible = true;//Можно ли запускать куротину

    public void AddQueue(IEnumerator Coroutine)
    {
        if (ArrDownloadImage != null)
        {
            Action[] Arr = new Action[ArrDownloadImage.Length + 1];
            for (int i = 0; i < ArrDownloadImage.Length; i++)
            {
                Arr[i] = ArrDownloadImage[i];
            }
            Arr[ArrDownloadImage.Length] = new Action(() => {
                File_Controller.PluginFolder.CallStatic("Print", "AddQueue(IEnumerator Coroutine):"+ Arr.Length.ToString());
                StartCoroutine((Coroutine)); });
            ArrDownloadImage = Arr;
        }
        else
        {
            ArrDownloadImage = new Action[] { () => {
                File_Controller.PluginFolder.CallStatic("Print", "AddQueue(IEnumerator Coroutine):"+ "First");
                StartCoroutine((Coroutine)); } };
        }
    }
    public void StartQueue()
    {
        if (ArrDownloadImage == null || ArrDownloadImage.Length == 0) { return; }
        for (int i = 0; i < ArrDownloadImage.Length;i++)
        {
            IsLaunchPossible = true;
            ArrDownloadImage[i].Invoke();
            while (!IsLaunchPossible) { }
        }
    }
    public void Remove()
    {
        IsLaunchPossible = true ;
        ArrDownloadImage = null ;
    }
    private IEnumerator StartEnumerator(IEnumerator Coroutine)
    {
        IsLaunchPossible = false;
        yield return Coroutine;
        IsLaunchPossible = true;

    }
}

