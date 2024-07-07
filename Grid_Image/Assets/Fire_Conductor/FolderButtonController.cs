using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FolderButtonController : MonoBehaviour
{
    //[SerializeField]
    private Button[] ButtonsFolder;
    //[SerializeField]
    private Button ButtonExitingFolder;
    //[SerializeField]
    private Button[] ButtonsBackForward;
    //[SerializeField]
    private TextMeshPro[] ButtonsTextMeshPro = new TextMeshPro[4];
    private Folder SelectedFolder;
    private int CountFolder;
    private int IndexNextFolder;
    private static int IndexSelectedFolder;

    public UnityAction OnClickButtonExitingFolder;
    public UnityAction OnClickOpenFolder;
    public void UpdateButtons()
    {
        for (int i = 0; i < ButtonsFolder.Length; i++)
        {
            if (IndexNextFolder < CountFolder && IndexNextFolder >= 0)
            {
                ButtonsFolder[i].onClick.RemoveAllListeners();
                ButtonsFolder[i].onClick.AddListener(() => { IndexSelectedFolder = IndexNextFolder;
                                                             OnClickOpenFolder();});
                ButtonsFolder[i].gameObject.transform.parent.gameObject.SetActive(true);
                ButtonsTextMeshPro[i].text = SelectedFolder[i].GetDirectoryInfo.Name;
                IndexNextFolder++;
            }
            else
            {
                ButtonsFolder[i].onClick.RemoveAllListeners();
                ButtonsFolder[i].gameObject.transform.parent.gameObject.SetActive(false);
            }
        }
    }
    public static int GetIndexSelectedFolder => IndexSelectedFolder;
    private void ButtonInitialization()
    {
        GameObject ThisParentGameObject = this.gameObject.transform.parent.parent.parent.gameObject;
        GameObject[] ArrayGameObjects = ThisParentGameObject.GetComponentsInChildren<GameObject>();
        ButtonsFolder = new Button[ArrayGameObjects.Length-2];
        for (int i = 0; i < ArrayGameObjects.Length-2; i++)
        {
            ButtonsFolder[i] = ArrayGameObjects[i].GetComponentInChildren<Button>();
        }
        ButtonExitingFolder = ArrayGameObjects[ArrayGameObjects.Length-1].GetComponent<Button>();
        GameObject game = ThisParentGameObject.transform.
            GetChild(ThisParentGameObject.transform.childCount - 2).gameObject;
        ButtonsBackForward = game.GetComponentsInChildren<Button>();

        ButtonsTextMeshPro = new TextMeshPro[ButtonsFolder.Length];
        for (int i = 0; i < ButtonsFolder.Length; i++)
        {
            ButtonsTextMeshPro[i] = ArrayGameObjects[i].GetComponentInChildren<TextMeshPro>();
        }
    }
    public FolderButtonController (Folder SelectedFolder)
    {
        ButtonInitialization();
        this.SelectedFolder = SelectedFolder;
        CountFolder = this.SelectedFolder.GetCountFolder;
        IndexNextFolder = 0;
        ButtonExitingFolder.onClick.AddListener(OnClickButtonExitingFolder);
        ButtonsBackForward[0].onClick.AddListener(() => { IndexNextFolder -= ButtonsFolder.Length;
                                                          UpdateButtons();});//может и не работать
        ButtonsBackForward[1].onClick.AddListener(() => { IndexNextFolder += ButtonsFolder.Length;
                                                          UpdateButtons();});
        UpdateButtons();//может и не надо тут его вызывать
    }
}
