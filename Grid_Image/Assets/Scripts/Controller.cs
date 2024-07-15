using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private File_Controller controllerFile_Controller;
    [SerializeField]
    private Image ImageResult;
    [SerializeField]//
    private Texture2D SelectedTexture;
    private float HeightImage;
    private float WidthImage;


    private void Awake()
    {
        //controllerFile_Controller.OnClickSaveButtonFile += () => { OnClickSaveButton(); };
        HeightImage = ImageResult.rectTransform.rect.height;
        WidthImage = ImageResult.rectTransform.rect.width;
        OnClickSaveButton();
    }
    private void OnClickSaveButton()
    {
        //SelectedTexture = controllerFile_Controller.GetTexture();
        Sprite sprite = Sprite.Create
            (SelectedTexture, new Rect(0, 0, SelectedTexture.width, SelectedTexture.height), new Vector2(0.5f, 0.5f), 100f);
        ImageResult.overrideSprite = sprite;
        ScaleImage(SelectedTexture.width, SelectedTexture.height);
    }
    private Texture2D CopyTexture(Texture2D source)
    {
        Texture2D tex = new Texture2D(source.width, source.height);
        for (int i = 0; i < tex.width; i++)
        {
            for (int j = 0; j < tex.height; j++)
            {
                tex.SetPixel(i, j,source.GetPixel(i,j));
            }
        }
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 1000f);
        var bytes = sprite.texture.EncodeToJPG();
        ImageConversion.LoadImage(tex, bytes);
        return tex;
    }
    private void ScaleImage(Image source)
    {
        source.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, SelectedTexture.width);
        source.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, SelectedTexture.height);
    }
    private void ScaleImage(float width, float height)
    {
        ImageResult.rectTransform.rotation = Quaternion.Euler(0, 0, 0);
        float newWidth;
        float newHeight;
        if (height >= width)
        {
            newWidth = width * (WidthImage/ height);
            if (newWidth <= HeightImage)
            {
                ImageResult.rectTransform.SetSizeWithCurrentAnchors
                    (RectTransform.Axis.Vertical, WidthImage);
                ImageResult.rectTransform.SetSizeWithCurrentAnchors
                    (RectTransform.Axis.Horizontal, newWidth);
            }
            else
            {
                float c = newWidth/HeightImage;
                newWidth = newWidth / c;
                newHeight = WidthImage / c;
                ImageResult.rectTransform.SetSizeWithCurrentAnchors
                    (RectTransform.Axis.Vertical, newHeight);
                ImageResult.rectTransform.SetSizeWithCurrentAnchors
                    (RectTransform.Axis.Horizontal, newWidth);
            }
            ImageResult.rectTransform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            newHeight = height / (width / WidthImage);
            if (newHeight <= HeightImage)
            {
                ImageResult.rectTransform.SetSizeWithCurrentAnchors
                    (RectTransform.Axis.Vertical, newHeight);
            }
            else
            {
                float c = newHeight / HeightImage;
                newHeight /= c;
                newWidth = WidthImage / c;
                ImageResult.rectTransform.SetSizeWithCurrentAnchors
                    (RectTransform.Axis.Vertical, newHeight);
                ImageResult.rectTransform.SetSizeWithCurrentAnchors
                    (RectTransform.Axis.Horizontal, newWidth);
            }
        }
    }
}
