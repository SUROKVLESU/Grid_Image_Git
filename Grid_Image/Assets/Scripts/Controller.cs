using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;
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
    private Button GridButton;
    [SerializeField]
    private Button PrintButton;
    [SerializeField] 
    private Button SaveButton;
    [SerializeField]
    private GameObject[] GameObjectRGB;
    [SerializeField]
    private GameObject Interface;

    private static CubicKangeFilled[] CubicKangeFilleds;
    private static Color[] CubicColor;

    private static RGBValue[] RGBValue;
    private static int CubicIndex;
    private static Image ImageCubic;


    private void Awake()
    {
        controllerFile_Controller.OnClickSaveButtonFile += () => { OnClickSaveButton(); };//===================
        SetRGB();
        HeightImage = ImageResult.rectTransform.rect.height;
        WidthImage = ImageResult.rectTransform.rect.width;
        PrintButton.enabled = false;
        PrintButton.transform.GetComponent<Image>().color = Color.red;
        GridButton.onClick.AddListener(() => 
        {
            SetActiveRGB(false);
            DestroyGrid();
            PrintButton.enabled = true;
            PrintButton.transform.GetComponent<Image>().color = Color.white;
            OnClickGridButton();
        } );
        PrintButton.onClick.AddListener(() => 
        {
            SetActiveRGB(false);
            DestroyGrid();
            SelectedTexture = ServiceImage.CreateTexture2D(SelectedTexture);
            ServiceImage.PrintAllTexture(SelectedTexture, CubicKangeFilleds, CubicColor);
            ImageResult.overrideSprite = ServiceImage.CreateSprite(SelectedTexture);
        });
        SaveButton.onClick.AddListener(() => 
        {
            OnClickSave();
        });
        //OnClickSaveButton();//==============================
    }
    private void Start()
    {
        Interface.SetActive(false);//============================
    }
    private void OnClickSaveButton()
    {
        Interface.SetActive(true);
        SelectedTexture = controllerFile_Controller.GetTexture();//==============================
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
    private void OnClickGridButton()
    {
        CubicKangeFilleds = ServiceCubic.CreateArrayCubic();
        CubicColor = new Color[CubicKangeFilleds.Length];
        for (int i = 0;i < CubicKangeFilleds.Length;i++)
        {
            new BoxCollider2DObject(ImageResult, CubicKangeFilleds[i],i,GridSprite);
        }
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
    private void OnClickSave()
    {
        var bytes = SelectedTexture.EncodeToJPG();
        System.IO.File.WriteAllBytes
            (File_Controller.PluginFolder.CallStatic<string>("GetRootDirectory") +"/Download/"
                + Random.Range(0, int.MaxValue) + ".png", bytes);
    }
    public static void SetActiveRGB(bool active) 
    {
        for (int i = 0;i< RGBValue.Length;i++)
        {
            RGBValue[i].transform.parent.gameObject.SetActive(active);
        }
    }
    private void DestroyGrid()
    {
        Transform Object = ImageResult.rectTransform.GetChild(0);
        for (int i = 0; i < ImageResult.rectTransform.GetChild(0).childCount; i++)
        {
            Destroy(Object.GetChild(i).gameObject);
        }
    }
    private void SetRGB()
    {
        RGBValue = new RGBValue[GameObjectRGB.Length];
        for (int i = 0; i < GameObjectRGB.Length; i++)
        {
            RGBValue[i] = GameObjectRGB[i].transform.GetChild(0).GetComponent<RGBValue>();
        }
    }
    public static void SetSelectedBoxCollider(int index)
    {
        CubicIndex = index;
    }
    public static void SetImageCubic(Image image)
    {
        ImageCubic = image;
        for (int i = 0; i < RGBValue.Length; i++)
        {
            if (CubicColor[CubicIndex] == null)
            {
                switch (i)
                {
                    case 0:
                        RGBValue[i].Value = image.color.r;
                        break;
                    case 1:
                        RGBValue[i].Value = image.color.g;
                        break;
                    case 2:
                        RGBValue[i].Value = image.color.b;
                        break;
                }
                RGBValue[i].SetText();
            }
            else
            {
                switch(i)
                {
                    case 0:
                        RGBValue[i].Value = CubicColor[CubicIndex].r;
                        break;
                    case 1:
                        RGBValue[i].Value = CubicColor[CubicIndex].g;
                        break;
                    case 2:
                        RGBValue[i].Value = CubicColor[CubicIndex].b;
                        break;
                }
                RGBValue[i].SetText();
            }

        }
    }
    public static void ShiftRGB()
    {
        ImageCubic.color = new Color(RGBValue[0].Value, RGBValue[1].Value, RGBValue[2].Value, ImageCubic.color.a);
        CubicColor[CubicIndex] = new Color(RGBValue[0].Value, RGBValue[1].Value, RGBValue[2].Value, 0);
    }

}
