using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class WWWTest : MonoBehaviour
{
    public Image image;
    public static AndroidJavaClass PluginFolder;
    private string path ;
    private void Start()
    {
        PluginFolder = new AndroidJavaClass("com.example.mylibrarytest.PluginFolder");
        path = Application.dataPath;
        PluginFolder.CallStatic("Print",path);
        StartCoroutine(DownloadImage2(path));
    }
    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        Debug.Log("Tic");
        yield return request.SendWebRequest();
            //image.texture = ((DownloadHandlerTexture) request.downloadHandler).texture;

        Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
        image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,tex.width);
        image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, tex.height);
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 1, tex.height / 1));
            image.overrideSprite = sprite;
    }
    IEnumerator DownloadImage2(string MediaUrl)
    {
        float widthImage = image.rectTransform.rect.width;
        float heightImage = image.rectTransform.rect.width;
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;

        float newWidth = tex.width / (tex.height / heightImage);
        if(newWidth <= widthImage)
        {
            image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heightImage);
            image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, tex.width / (tex.height / heightImage));
        }
        else
        {
            image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, tex.height/(tex.width/widthImage));
            image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, widthImage);
        }

        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 1, tex.height / 1));
        image.overrideSprite = sprite;
    }
}

