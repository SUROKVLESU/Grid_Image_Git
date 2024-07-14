using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;


public class WWWTest : MonoBehaviour
{
    public Image image;
    //public static AndroidJavaClass PluginFolder;
    private string path ;
    private byte[] Mybytes;
    private void Start()
    {
        path = "C:\\1.png";
        Mybytes = File.ReadAllBytes(path);
        Texture2D texture2D = new Texture2D(700,700);
        ImageConversion.LoadImage(texture2D, Mybytes);
        image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, texture2D.width);
        image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, texture2D.height);
        Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 1000f);
        image.overrideSprite = sprite;

        string jpgFile = "C:\\Test\\22.png";
        //Texture2D tex = new Texture2D(Screen.width, Screen.height);
        //tex = new Texture2D(sprite.texture);
        //tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        //tex.Apply();
        var bytes = sprite.texture.EncodeToJPG();
        //Destroy(tex);
        System.IO.File.WriteAllBytes(jpgFile, bytes);
    }
}

