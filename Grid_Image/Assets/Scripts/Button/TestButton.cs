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
        Texture2D newTexture2D = ServiceImage.CreateTexture2D(TestImage.sprite.texture);
        ServiceImage.PrintAllTexture(newTexture2D);
        TestImage.overrideSprite = ServiceImage.CreateSprite(newTexture2D);
        Debug.Log("Finisch");
    }
}
