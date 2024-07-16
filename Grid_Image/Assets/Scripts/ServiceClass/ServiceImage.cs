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
    public static void PrintNewTexture(Texture2D texture,CubicKangeFilled cubic,Color color)
    {
        for (int i = (int)((cubic.RightY/100f) * texture.width); i <= (int)((cubic.LeftY/100f) * texture.width); i++)
        {
            for (int j = (int)((cubic.LeftX / 100f) * texture.height); j <= (int)((cubic.RightX / 100f) * texture.height); j++)
            {
                texture.SetPixel(i, j, texture.GetPixel(i, j)+color);
            }
        }
    }
    public static void PrintNewTexture(Texture2D texture, CubicKangeFilled cubic)
    {
        Color color = new Color(0f,0f,0f,0f);
        for (int i = (int)((cubic.RightY / 100f) * texture.width); i <= (int)((cubic.LeftY / 100f) * texture.width); i++)
        {
            for (int j = (int)((cubic.LeftX / 100f) * texture.height); j <= (int)((cubic.RightX / 100f) * texture.height); j++)
            {
                texture.SetPixel(i, j, texture.GetPixel(i, j) + color);
            }
        }
    }
    public static void PrintAllTexture(Texture2D texture)
    {
        CubicKangeFilled[] cubics = ServiceCubic.CreateArrayCubic();
        for (int i = 0; i < cubics.Length; i++)
        {
            PrintNewTexture
                (texture, cubics[i], new Color(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0));
        }
    }
}
