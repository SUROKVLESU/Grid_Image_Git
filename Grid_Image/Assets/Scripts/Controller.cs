using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private File_Controller controllerFile_Controller;
    [SerializeField]
    private Image ImageResult;
    [SerializeField]
    private Texture2D SelectedTexture;
    [SerializeField]
    private Sprite GridSprite;
    private float HeightImage;
    private float WidthImage;
    [SerializeField]
    private Button TestButton;


    private void Awake()
    {
        //controllerFile_Controller.OnClickSaveButtonFile += () => { OnClickSaveButton(); };
        HeightImage = ImageResult.rectTransform.rect.height;
        WidthImage = ImageResult.rectTransform.rect.width;
        TestButton.onClick.AddListener(() => { OnClickTest(); });
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
    private void OnClickTest()
    {
        SelectedTexture = ServiceImage.CreateTexture2D(SelectedTexture);
        CubicKangeFilled[] cubics = ServiceCubic.CreateArrayCubic();
        ServiceImage.PrintAllTexture(SelectedTexture, cubics);
        for (int i = 0;i < cubics.Length;i++)
        {
            new BoxCollider2DObject(ImageResult, cubics[i],i,GridSprite);
        }
        /*ServiceImage.PrintNewTexture(SelectedTexture,
            new CubicKangeFilled(new Vector2Int(25, 75), new Vector2Int(75, 25)),
            new Color(0.2f, -0.2f, 0.4f));
        new BoxCollider2DObject
            (ImageResult, new CubicKangeFilled(new Vector2Int(25, 75), new Vector2Int(75, 25)), 0, GridSprite);

        ServiceImage.PrintNewTexture(SelectedTexture,
            new CubicKangeFilled(new Vector2Int(0, 25), new Vector2Int(25, 0)),
            new Color(0.2f, 0.2f, -0.4f));
        new BoxCollider2DObject
            (ImageResult, new CubicKangeFilled(new Vector2Int(0, 25), new Vector2Int(25, 0)), 0, GridSprite);*/

        ImageResult.overrideSprite = ServiceImage.CreateSprite(SelectedTexture);
        Debug.Log("Finisch");
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
