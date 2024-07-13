using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


internal class FileButtonController : MonoBehaviour
{
    private GroupFiles SelectedGroupFiles;
    private int IndexNextFile;
    private static int IndexSelectedFile = 0;

    private Text[] TextFile;
    private Button[] ButtonsFile;
    private Button[] ButtonsBackForward;
    private Image[] ImagesFile;

    public void ButtonInitialization()
    {
        Transform ThisParentGameObject = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(1);
        GameObject[] ArrayGameObjects = new GameObject[ThisParentGameObject.childCount];
        for (int i = 0; i < ArrayGameObjects.Length; i++)
        {
            ArrayGameObjects[i] = ThisParentGameObject.GetChild(i).gameObject;
        }
        TextFile = new Text[ArrayGameObjects.Length-1];//Смотри дерево объектов в Unity
        ButtonsFile = new Button[TextFile.Length];
        ImagesFile = new Image[TextFile.Length];
        for (int i = 0; i < TextFile.Length; i++)
        {
            TextFile[i] = ArrayGameObjects[i].GetComponentInChildren<Text>();
            ButtonsFile[i] = ArrayGameObjects[i].GetComponentInChildren<Button>();
            ImagesFile[i] = ArrayGameObjects[i].GetComponentInChildren<Image>();
        }
        ButtonsBackForward = ArrayGameObjects[ArrayGameObjects.Length-1].GetComponentsInChildren<Button>();
        ButtonsBackForward[0].onClick.AddListener(() => {
            IndexNextFile -= ButtonsFile.Length;
            UpdateButtons();
        });
        ButtonsBackForward[1].onClick.AddListener(() => {
            IndexNextFile += ButtonsFile.Length;
            UpdateButtons();
        });
    }
    public void ChangingSelectedGroupFiles(GroupFiles groupFiles)
    {
        SelectedGroupFiles = groupFiles;
        UpdateButtons();
    }
    public void UpdateButtons()
    {
        if (!(IndexNextFile < SelectedGroupFiles.GetCountFile && IndexNextFile >= 0)) IndexNextFile = 0;
        for (int i = 0; i < ButtonsFile.Length; i++)
        {
            if (IndexNextFile + i < SelectedGroupFiles.GetCountFile && IndexNextFile + i >= 0)
            {
                ButtonsFile[i].onClick.RemoveAllListeners();
                switch (i)
                {
                    case 0:
                        ButtonsFile[0].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 0;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 1:
                        ButtonsFile[1].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 1;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 2:
                        ButtonsFile[2].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 2;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 3:
                        ButtonsFile[3].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 3;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 4:
                        ButtonsFile[4].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 4;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 5:
                        ButtonsFile[5].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 5;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 6:
                        ButtonsFile[6].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 6;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 7:
                        ButtonsFile[7].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 8;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 8:
                        ButtonsFile[8].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 8;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 9:
                        ButtonsFile[9].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 9;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 10:
                        ButtonsFile[10].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 10;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 11:
                        ButtonsFile[11].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 11;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 12:
                        ButtonsFile[12].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 12;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 13:
                        ButtonsFile[13].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 13;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 14:
                        ButtonsFile[14].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 14;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 15:
                        ButtonsFile[15].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 15;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 16:
                        ButtonsFile[16].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 16;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 17:
                        ButtonsFile[17].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 17;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 18:
                        ButtonsFile[18].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 18;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 19:
                        ButtonsFile[19].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 19;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 20:
                        ButtonsFile[20].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 20;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 21:
                        ButtonsFile[21].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 21;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 22:
                        ButtonsFile[22].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 22;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 23:
                        ButtonsFile[23].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 23;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 24:
                        ButtonsFile[24].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 24;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 25:
                        ButtonsFile[25].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 25;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 26:
                        ButtonsFile[26].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 26;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 27:
                        ButtonsFile[27].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 27;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 28:
                        ButtonsFile[28].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 28;
                            //OnClickOpenFolder();
                        });
                        break;
                    case 29:
                        ButtonsFile[29].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 29;
                            //OnClickOpenFolder();
                        });
                        break;
                }
                ButtonsFile[i].gameObject.transform.parent.gameObject.SetActive(true);
                TextFile[i].text =
                    File_Controller.PluginFolder.CallStatic<string>
                    ("GetFileName", SelectedGroupFiles[IndexNextFile + i]);
                if(IsImage(SelectedGroupFiles[IndexNextFile + i]))
                {
                    StartCoroutine(DownloadImage(SelectedGroupFiles[IndexNextFile + i], ImagesFile[i]));
                }
            }
            else
            {
                ButtonsFile[i].onClick.RemoveAllListeners();
                ButtonsFile[i].gameObject.transform.parent.gameObject.SetActive(false);
            }
        }
    }
    IEnumerator DownloadImage(string MediaUrl,Image image)
    {
        float widthImage = image.rectTransform.rect.width;
        float heightImage = image.rectTransform.rect.width;
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;

        float newWidth = tex.width / (tex.height / heightImage);
        if (newWidth <= widthImage)
        {
            image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heightImage);
            image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, tex.width / (tex.height / heightImage));
        }
        else
        {
            image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, tex.height / (tex.width / widthImage));
            image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, widthImage);
        }

        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 1, tex.height / 1));
        image.overrideSprite = sprite;
    }
    private bool IsImage(string path)
    {
        string ext = Path.GetExtension(path);
        if (ext.Equals(".png")) {  return true; };
        if (ext.Equals(".jpeg")) { return true; };
        if (ext.Equals(".jpg")) { return true; };
        return false;
    }
}

