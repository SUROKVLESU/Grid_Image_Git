using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FolderButtonController : MonoBehaviour
{
    private Button[] ButtonsFolder;
    private Button ButtonExitingFolder;
    private Button[] ButtonsBackForward;
    private Text[] ButtonsTextMeshPro;
    private Folder SelectedFolder;
    private int IndexNextFolder;
    private static int IndexSelectedFolder = 0;

    public UnityAction OnClickButtonExitingFolder = new UnityAction(()=> { });
    public UnityAction OnClickOpenFolder = new UnityAction(() => { });


    public void UpdateButtons()
    {
        if (!(IndexNextFolder < SelectedFolder.GetCountFolder && IndexNextFolder >= 0)) IndexNextFolder = 0;
        for (int i = 0; i < ButtonsFolder.Length; i++)
        {
            if (IndexNextFolder + i < SelectedFolder.GetCountFolder && IndexNextFolder + i >= 0)
            {
                ButtonsFolder[i].onClick.RemoveAllListeners();
                switch (i)
                {
                    case 0:
                        ButtonsFolder[0].onClick.AddListener(() => {
                            IndexSelectedFolder = IndexNextFolder + 0;
                            OnClickOpenFolder();
                        });
                        break;
                    case 1:
                        ButtonsFolder[1].onClick.AddListener(() => {
                            IndexSelectedFolder = IndexNextFolder + 1;
                            OnClickOpenFolder();
                        });
                        break;
                    case 2:
                        ButtonsFolder[2].onClick.AddListener(() => {
                            IndexSelectedFolder = IndexNextFolder + 2;
                            OnClickOpenFolder();
                        });
                        break;
                    case 3:
                        ButtonsFolder[3].onClick.AddListener(() => {
                            IndexSelectedFolder = IndexNextFolder + 3;
                            OnClickOpenFolder();
                        });
                        break;
                    case 4:
                        ButtonsFolder[4].onClick.AddListener(() => {
                            IndexSelectedFolder = IndexNextFolder + 4;
                            OnClickOpenFolder();
                        });
                        break;
                    case 5:
                        ButtonsFolder[5].onClick.AddListener(() => {
                            IndexSelectedFolder = IndexNextFolder + 5;
                            OnClickOpenFolder();
                        });
                        break;
                    case 6:
                        ButtonsFolder[6].onClick.AddListener(() => {
                            IndexSelectedFolder = IndexNextFolder + 6;
                            OnClickOpenFolder();
                        });
                        break;
                    case 7:
                        ButtonsFolder[7].onClick.AddListener(() => {
                            IndexSelectedFolder = IndexNextFolder + 7;
                            OnClickOpenFolder();
                        });
                        break;
                }
                ButtonsFolder[i].gameObject.transform.parent.gameObject.SetActive(true);
                ButtonsTextMeshPro[i].text =
                    File_Controller.PluginFolder.CallStatic<string>("GetDirectoryName", SelectedFolder[IndexNextFolder + i].GetDirectoryInfo);
                //SelectedFolder[IndexNextFolder + i].GetDirectoryInfo.Name;
            }
            else
            {
                ButtonsFolder[i].onClick.RemoveAllListeners();
                ButtonsFolder[i].gameObject.transform.parent.gameObject.SetActive(false);
            }
        }
    }
    public static int GetIndexSelectedFolder => IndexSelectedFolder;
    public void ButtonInitialization()
    {
        Transform ThisParentGameObject = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0);
        GameObject[] ArrayGameObjects = new GameObject[ThisParentGameObject.childCount];
        for (int i = 0; i < ArrayGameObjects.Length; i++)
        {
            ArrayGameObjects[i] = ThisParentGameObject.GetChild(i).gameObject;
        }
        ButtonsFolder = new Button[ArrayGameObjects.Length-2];
        for (int i = 0; i < ArrayGameObjects.Length-2; i++)
        {
            ButtonsFolder[i] = ArrayGameObjects[i].GetComponentInChildren<Button>();
        }
        ButtonExitingFolder = ArrayGameObjects[ArrayGameObjects.Length - 1].GetComponent<Button>();
        ButtonsBackForward = ArrayGameObjects[ArrayGameObjects.Length - 2].GetComponentsInChildren<Button>();
        ButtonsTextMeshPro = new Text[ButtonsFolder.Length];
        for (int i = 0; i < ButtonsFolder.Length; i++)
        {
            ButtonsTextMeshPro[i] = ButtonsFolder[i].transform.parent.GetComponentInChildren<Text>();
        }
        ButtonExitingFolder.onClick.AddListener(()=> OnClickButtonExitingFolder());
        ButtonsBackForward[0].onClick.AddListener(() => {
            IndexNextFolder -= ButtonsFolder.Length;
            UpdateButtons();
        });
        ButtonsBackForward[1].onClick.AddListener(() => {
            IndexNextFolder += ButtonsFolder.Length;
            UpdateButtons();
        });
    }
    public void Initialization (Folder SelectedFolder)
    {
        this.SelectedFolder = SelectedFolder;
        IndexNextFolder = 0;
    }
}
