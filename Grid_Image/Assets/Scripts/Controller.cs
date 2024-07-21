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
    private Texture2D NewTexture;
    [SerializeField]
    private Sprite GridSprite;
    private float HeightImage;
    private float WidthImage;
    [SerializeField]
    private Button GridButton;
    [SerializeField] 
    private Button NewGridButton;
    [SerializeField] 
    private Button OldGridButton;
    [SerializeField]
    private Button PrintButton;
    [SerializeField] 
    private Button SaveButton;
    [SerializeField] 
    private Button FolderButton;
    [SerializeField]
    private GameObject[] GameObjectRGB;
    [SerializeField]
    private GameObject Interface;
    [SerializeField]
    private Image ColorNewOdj;
    [SerializeField]
    private Button NumberGridButton;
    [SerializeField]
    private Text NumberGridText;
    private int NumberGrid = 1;

    private static CubicKangeFilled[] CubicKangeFilleds;
    private static Color[] CubicColor;

    private static RGBValue[] RGBValue;
    private static int CubicIndex;
    private static Image ImageCubic;
    private static Image ColorCubicNew;


    private void Awake()
    {
        controllerFile_Controller.OnClickSaveButtonFile += () => { OnClickSaveButton(); };//===================
        SetRGB();
        SetColorCubicNew();
        HeightImage = ImageResult.rectTransform.rect.height;
        WidthImage = ImageResult.rectTransform.rect.width;
        PrintButton.enabled = false;
        PrintButton.transform.GetComponent<Image>().color = Color.red;
        NumberGridButton.onClick.AddListener(() => 
        {
            SetActiveRGB(false);
            NumberGrid++;
            if (NumberGrid == 3)
            {
                NumberGrid = 1;
            }
            NumberGridText.text = NumberGrid.ToString();
        });
        FolderButton.onClick.AddListener(() =>
        {
            DestroyGrid();
            SetActiveGridButton(false);
            Interface.gameObject.SetActive(false);
            controllerFile_Controller.gameObject.SetActive(true);
        });
        OldGridButton.onClick.AddListener(() =>
        {
            SetActiveRGB(false);
            ImageResult.rectTransform.GetChild(0).gameObject.SetActive(true);
            NewTexture = SelectedTexture;
            Sprite sprite = Sprite.Create
            (NewTexture, new Rect(0, 0, NewTexture.width, NewTexture.height), new Vector2(0.5f, 0.5f), 100f);
            ImageResult.overrideSprite = sprite;
            ScaleImage(NewTexture.width, NewTexture.height);
        });
        NewGridButton.onClick.AddListener(() =>
        {
            PrintButton.enabled = true;
            PrintButton.transform.GetComponent<Image>().color = Color.white;
            SetActiveRGB(false);
            ImageResult.rectTransform.GetChild(0).gameObject.SetActive(true);
            SetActiveRGB(false);
            DestroyGrid();
            OnClickGridButton();
        });
        GridButton.onClick.AddListener(() => 
        {
            SetActiveRGB(false);
            SetActiveGridButton(!NewGridButton.gameObject.activeSelf);
            NumberGridText.text = NumberGrid.ToString();
        } );
        PrintButton.onClick.AddListener(() => 
        {
            SetActiveRGB(false);
            ImageResult.rectTransform.GetChild(0).gameObject.SetActive(false);
            //DestroyGrid();
            NewTexture = ServiceImage.CreateTexture2D(SelectedTexture);
            ServiceImage.PrintAllTexture(NewTexture, CubicKangeFilleds, CubicColor);
            ImageResult.overrideSprite = ServiceImage.CreateSprite(NewTexture);
        });
        SaveButton.onClick.AddListener(() => 
        {
            SetActiveGridButton(false);
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
        ImageResult.rectTransform.GetChild(0).gameObject.SetActive(false);
        //DestroyGrid();
        Interface.SetActive(true);
        SelectedTexture = controllerFile_Controller.GetTexture();//==============================
        NewTexture = SelectedTexture;
        Sprite sprite = Sprite.Create
            (NewTexture, new Rect(0, 0, NewTexture.width, NewTexture.height), new Vector2(0.5f, 0.5f), 100f);
        ImageResult.overrideSprite = sprite;
        ScaleImage(NewTexture.width, NewTexture.height);
        SetActiveGridButton(false);
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
        switch(NumberGrid)
        {
            case 1:
                CubicKangeFilleds = ServiceCubic.CreateArrayCubicV1();
                break;
            case 2:
                CubicKangeFilleds = ServiceCubic.CreateArrayCubicV2();
                break;
        }
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
        var bytes = NewTexture.EncodeToJPG();
        System.IO.File.WriteAllBytes
            (Plugin.PluginFolder.CallStatic<string>("GetRootDirectory") +"/DCIM/Camera/"
                + Random.Range(0, int.MaxValue) + ".jpg", bytes);
    }
    public void SetActiveGridButton(bool active)
    {
        NewGridButton.gameObject.SetActive (active);
        OldGridButton.gameObject.SetActive(active);
        NumberGridButton.gameObject .SetActive (active);
    }
    public static void SetActiveRGB(bool active) 
    {
        for (int i = 0;i< RGBValue.Length;i++)
        {
            RGBValue[i].gameObject.SetActive(active);
        }
        ColorCubicNew.gameObject.SetActive(active);
    }
    private void DestroyGrid()
    {
        Transform Object = ImageResult.rectTransform.GetChild(0);
        for (int i = 0; i < ImageResult.rectTransform.GetChild(0).childCount; i++)
        {
            Destroy(Object.GetChild(i).gameObject);
        }
    }
    private void SetColorCubicNew()
    {
        ColorCubicNew = ColorNewOdj;
    }
    private void SetRGB()
    {
        RGBValue = new RGBValue[GameObjectRGB.Length];
        for (int i = 0; i < GameObjectRGB.Length; i++)
        {
            RGBValue[i] = GameObjectRGB[i].GetComponent<RGBValue>();
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
        ColorCubicNew.color = new Color(RGBValue[0].Value, RGBValue[1].Value, RGBValue[2].Value, 1);
    }
    public static void ShiftRGB()
    {
        ImageCubic.color = new Color(RGBValue[0].Value, RGBValue[1].Value, RGBValue[2].Value, ImageCubic.color.a);
        CubicColor[CubicIndex] = new Color(RGBValue[0].Value, RGBValue[1].Value, RGBValue[2].Value, 0);
        ColorCubicNew.color = new Color(RGBValue[0].Value, RGBValue[1].Value, RGBValue[2].Value, 1);
    }

}
