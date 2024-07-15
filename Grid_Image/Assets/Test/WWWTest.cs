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
        Texture2D texture2D = new Texture2D(100,100);
        ImageConversion.LoadImage(texture2D, Mybytes);
        image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, texture2D.width);
        image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, texture2D.height);
        //Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 1000f);
        //image.overrideSprite = sprite;
        //Sprite sprite1 = sprite;

        Color MyColor;
        for(int i = 0; i < texture2D.width; i++)
        {
            for (int j = 0; j < texture2D.height; j++)
            {
                MyColor = texture2D.GetPixel(i, j);
                if (i < 400)
                {
                    texture2D.SetPixel(i, j, new Color
                        (MyColor.r + 0.2f, MyColor.g - 0.2f, MyColor.b + 0.4f, MyColor.a));//r g b a
                }
                else {
                    texture2D.SetPixel(i, j, MyColor);
                }
            }
        }
        Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 1000f);
        image.sprite = sprite;
        string jpgFile = "C:\\Test\\22.png";
        var bytes = sprite.texture.EncodeToJPG();
        ImageConversion.LoadImage(texture2D, bytes);
        sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 1000f);
        image.sprite = sprite;
        System.IO.File.WriteAllBytes(jpgFile, bytes);

    }

    private void Print(string path, Image image)
    {
        byte[] bytes = File.ReadAllBytes(path);
        Texture2D tex = new Texture2D(700, 700);
        if (ImageConversion.LoadImage(tex, bytes, true))
        {
            //ScaleImage(image, tex.width, tex.height);
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));//tex.width / 2, tex.height / 2
            image.overrideSprite = sprite;

            image.gameObject.transform.parent.gameObject.SetActive(true);
        }
    }
}

