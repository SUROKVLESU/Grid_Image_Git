using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private File_Controller controllerFile_Controller;
    [SerializeField]
    private Image ImageResult;
    private Texture2D SelectedTexture;


    private void Awake()
    {
        controllerFile_Controller.OnClickSaveButtonFile += () => { OnClickSaveButton(); };
    }
    private void OnClickSaveButton()
    {
        SelectedTexture = controllerFile_Controller.GetTexture();
        Sprite sprite = Sprite.Create
            (SelectedTexture, new Rect(0, 0, SelectedTexture.width, SelectedTexture.height), new Vector2(0.5f, 0.5f), 100f);
        ImageResult.overrideSprite = sprite;
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
}
