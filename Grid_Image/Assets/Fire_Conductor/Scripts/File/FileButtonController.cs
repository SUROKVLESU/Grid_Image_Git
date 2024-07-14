using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
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

    private float WidthImage;
    private float HeightImage;
    private Sprite Sprite;

    private bool IsDownloadImage;
    private Coroutine[] Coroutine;

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
            ImagesFile[i] = ArrayGameObjects[i].transform.GetChild(2).GetComponent<Image>();
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
        WidthImage = ImagesFile[0].rectTransform.rect.width;
        HeightImage = ImagesFile[0].rectTransform.rect.height;
        Sprite = ImagesFile[0].sprite;
        Coroutine = new Coroutine[8];
    }
    public void ChangingSelectedGroupFiles(GroupFiles groupFiles)
    {
        SelectedGroupFiles = groupFiles;
        UpdateButtons();
    }
    public void UpdateButtons()
    {
        //System.GC.Collect();
        IsDownloadImage = true;
        foreach (var file in Coroutine)
        {
            if (file != null)
            {
                StopCoroutine(file);
            }
        }
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
                            if (IsImage(SelectedGroupFiles[IndexNextFile + i]))
                            {
                                Coroutine[0] = StartCoroutine(DownloadImage(SelectedGroupFiles[IndexNextFile + 0], ImagesFile[0]));
                                //Print(SelectedGroupFiles[IndexNextFile + i], ImagesFile[i]);
                            }
                        });
                        break;
                    case 1:
                        ButtonsFile[1].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 1;
                            if (IsImage(SelectedGroupFiles[IndexNextFile + 1]))
                            {
                                Coroutine[1] = StartCoroutine(DownloadImage(SelectedGroupFiles[IndexNextFile + 1], ImagesFile[1]));
                                //Print(SelectedGroupFiles[IndexNextFile + i], ImagesFile[i]);
                            }
                        });
                        break;
                    case 2:
                        ButtonsFile[2].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 2;
                            if (IsImage(SelectedGroupFiles[IndexNextFile + 2]))
                            {
                                Coroutine[2] = StartCoroutine(DownloadImage(SelectedGroupFiles[IndexNextFile + 2], ImagesFile[2]));
                                //Print(SelectedGroupFiles[IndexNextFile + i], ImagesFile[i]);
                            }
                        });
                        break;
                    case 3:
                        ButtonsFile[3].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 3;
                            if (IsImage(SelectedGroupFiles[IndexNextFile + 3]))
                            {
                                Coroutine[3] = StartCoroutine(DownloadImage(SelectedGroupFiles[IndexNextFile + 3], ImagesFile[3]));
                                //Print(SelectedGroupFiles[IndexNextFile + i], ImagesFile[i]);
                            }
                        });
                        break;
                    case 4:
                        ButtonsFile[4].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 4;
                            if (IsImage(SelectedGroupFiles[IndexNextFile + 4]))
                            {
                                Coroutine[4] = StartCoroutine(DownloadImage(SelectedGroupFiles[IndexNextFile + 4], ImagesFile[4]));
                                //Print(SelectedGroupFiles[IndexNextFile + i], ImagesFile[i]);
                            }
                        });
                        break;
                    case 5:
                        ButtonsFile[5].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 5;
                            if (IsImage(SelectedGroupFiles[IndexNextFile + 5]))
                            {
                                Coroutine[5] = StartCoroutine(DownloadImage(SelectedGroupFiles[IndexNextFile + 5], ImagesFile[5]));
                                //Print(SelectedGroupFiles[IndexNextFile + i], ImagesFile[i]);
                            }
                        });
                        break;
                    case 6:
                        ButtonsFile[6].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 6;
                            if (IsImage(SelectedGroupFiles[IndexNextFile + 6]))
                            {
                                Coroutine[6] = StartCoroutine(DownloadImage(SelectedGroupFiles[IndexNextFile + 6], ImagesFile[6]));
                                //Print(SelectedGroupFiles[IndexNextFile + i], ImagesFile[i]);
                            }
                        });
                        break;
                    case 7:
                        ButtonsFile[7].onClick.AddListener(() => {
                            IndexSelectedFile = IndexNextFile + 7;
                            if (IsImage(SelectedGroupFiles[IndexNextFile + 7]))
                            {
                                Coroutine[7] = StartCoroutine(DownloadImage(SelectedGroupFiles[IndexNextFile + 7], ImagesFile[7]));
                                //Print(SelectedGroupFiles[IndexNextFile + i], ImagesFile[i]);
                            }
                        });
                        break;
                }
                ButtonsFile[i].gameObject.transform.parent.gameObject.SetActive(true);
                TextFile[i].text =
                    File_Controller.PluginFolder.CallStatic<string>
                    ("GetFileName", SelectedGroupFiles[IndexNextFile + i]);
                //
                ImagesFile[i].rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, HeightImage);
                ImagesFile[i].rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, WidthImage);
                ImagesFile[i].rectTransform.rotation = Quaternion.Euler(0, 0, 0);
                ImagesFile[i].overrideSprite = Sprite;
                //
                /*if (IsImage(SelectedGroupFiles[IndexNextFile + i]))
                {
                    //Coroutine[i] = StartCoroutine(DownloadImage(SelectedGroupFiles[IndexNextFile + i], ImagesFile[i]));
                    //Print(SelectedGroupFiles[IndexNextFile + i], ImagesFile[i]);
                }*/
            }
            else
            {
                ButtonsFile[i].onClick.RemoveAllListeners();
                ButtonsFile[i].gameObject.transform.parent.gameObject.SetActive(false);
                Coroutine[i] = null;
            }
        }
    }
    private void Print(string path,Image image)
    {
        byte[] bytes = File.ReadAllBytes(path);
        Texture2D tex = new Texture2D(700, 700);
        if(ImageConversion.LoadImage(tex, bytes,true))
        {
            ScaleImage(image, tex.width, tex.height);
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));//tex.width / 2, tex.height / 2
            image.overrideSprite = sprite;

            image.gameObject.transform.parent.gameObject.SetActive(true);
        }
    }
    IEnumerator DownloadImage(string MediaUrl, Image image)
    {
        while (true)
        {
            if (IsDownloadImage)
            {
                IsDownloadImage = false;
                image.gameObject.transform.parent.gameObject.SetActive(false);

                using (UnityWebRequest request = UnityWebRequestTexture.GetTexture("file://" + MediaUrl))
                {
                    yield return request.SendWebRequest();
                    Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;

                    ScaleImage(image, tex.width, tex.height);

                    Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 5f);//tex.width / 2, tex.height / 2
                    image.overrideSprite = sprite;

                    image.gameObject.transform.parent.gameObject.SetActive(true);
                    //request.Dispose();
                    break;
                }
            }
            else
            {
                yield return new WaitForFixedUpdate();
            }
        }
        IsDownloadImage = true;
    }
    private void ScaleImage(Image image,float width,float height)
    {
        float newWidth;
        float newHeight;
        if (height>=width)
        {
            newWidth = width / (height / HeightImage);
            if (newWidth <= WidthImage)
            {
                image.rectTransform.SetSizeWithCurrentAnchors
                    (RectTransform.Axis.Horizontal, newWidth);
            }
            else
            {
                newHeight = HeightImage / (newWidth / WidthImage);
                image.rectTransform.SetSizeWithCurrentAnchors
                    (RectTransform.Axis.Vertical, newHeight);
            }
        }
        else
        {
            newHeight = height / (width / HeightImage);
            if (newHeight <= WidthImage)
            {
                image.rectTransform.SetSizeWithCurrentAnchors
                    (RectTransform.Axis.Vertical, newHeight);
                image.rectTransform.SetSizeWithCurrentAnchors
                    (RectTransform.Axis.Horizontal, HeightImage);
            }
            else
            {
                newWidth = HeightImage / (newHeight / WidthImage);
                image.rectTransform.SetSizeWithCurrentAnchors
                    (RectTransform.Axis.Vertical, WidthImage);
                image.rectTransform.SetSizeWithCurrentAnchors
                    (RectTransform.Axis.Horizontal, newWidth);
            }
            image.rectTransform.rotation = Quaternion.Euler(0, 0, 90);
        }
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

