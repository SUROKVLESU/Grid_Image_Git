using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.Provider;
using UnityEngine.UI;

public class TestButton : MonoBehaviour
{
    [SerializeField]
    private Image TestImage;
    [SerializeField]
    private Sprite TestSprite;
    private Button TButton;
    private void Awake()
    {
        TButton = GetComponent<Button>();
        TButton.onClick.AddListener(() => { OnClick22(); });
    }
    private void OnClick22()
    {
        Texture2D newTexture2D = ServiceImage.CreateTexture2D(TestImage.sprite.texture);
        //ServiceImage.PrintAllTexture(TestImage,newTexture2D,TestSprite);
        ServiceImage.PrintNewTexture(newTexture2D,
            new CubicKangeFilled(new Vector2Int(25,75), new Vector2Int(75,25)),
            new Color(0.2f,-0.2f,0.4f));
        new BoxCollider2DObject
            (TestImage, new CubicKangeFilled(new Vector2Int(25, 75), new Vector2Int(75, 25)), 0, TestSprite);

        ServiceImage.PrintNewTexture(newTexture2D,
            new CubicKangeFilled(new Vector2Int(0, 25), new Vector2Int(25, 0)),
            new Color(0.2f, 0.2f, -0.4f));
        new BoxCollider2DObject
            (TestImage, new CubicKangeFilled(new Vector2Int(0, 25), new Vector2Int(25, 0)), 0, TestSprite);

        TestImage.overrideSprite = ServiceImage.CreateSprite(newTexture2D);
        Debug.Log("Finisch");
    }
}
