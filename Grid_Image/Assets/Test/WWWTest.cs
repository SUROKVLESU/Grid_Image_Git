using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class WWWTest : MonoBehaviour
{
    public Image image;
    private string path = "C:\\n7deX6dFIok.jpg";
    private void Start()
    {
        StartCoroutine(DownloadImage(path));
    }
    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
            //image.texture = ((DownloadHandlerTexture) request.downloadHandler).texture;

        Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
        image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,tex.width);
        image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, tex.height);
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 1, tex.height / 1));
            image.overrideSprite = sprite;
    }
}
