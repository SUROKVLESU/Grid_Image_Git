using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceImage 
{
    public static Texture2D CreateTexture2D(Texture2D texture)
    {
        Texture2D newTexture2D = new Texture2D(texture.width, texture.height);
        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                newTexture2D.SetPixel(i, j, texture.GetPixel(i, j));
            }
        }
        return newTexture2D;
    }
    public static Sprite CreateSprite(Texture2D texture)
    {
        Sprite sprite = Sprite.Create
            (texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 1000f);
        var bytes = sprite.texture.EncodeToJPG();
        ImageConversion.LoadImage(texture, bytes);
        sprite = Sprite.Create
            (texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 1000f);
        return sprite;
    }
}
