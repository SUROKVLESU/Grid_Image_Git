using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.Provider;
using UnityEngine.UI;

public class TestButton : MonoBehaviour
{
    [SerializeField]
    private Image TestImage;
    private Button TButton;
    private bool IsBool = false;
    private void Awake()
    {
        TButton = GetComponent<Button>();
        TButton.onClick.AddListener(() => { OnClick22(); });
    }
    private void FixedUpdate()
    {
        if (IsBool)
        {
            OnClick22();
        }
    }
    private void OnClick22()
    {
        IsBool = false;
        Debug.Log("Start");
        Texture2D newTexture2D = ServiceImage.CreateTexture2D(TestImage.sprite.texture);
        Color MyColor;
        IsBool = false;
        for (int i = 0; i < newTexture2D.width; i++)
        {
            for (int j = 0; j < newTexture2D.height; j++)
            {
                MyColor = newTexture2D.GetPixel(i, j);
                newTexture2D.SetPixel(i, j, new Color
                        (MyColor.r + 0.2f, MyColor.g - 0.2f, MyColor.b + 0.4f, MyColor.a));//r g b a
            }
        }
        TestImage.overrideSprite = ServiceImage.CreateSprite(newTexture2D);
    }
}
