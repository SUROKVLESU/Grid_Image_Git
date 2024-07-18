using UnityEngine;
using UnityEngine.UI;

public class ScrollOnOffButton:MonoBehaviour
{
    [SerializeField]
    private Button TButton;
    [SerializeField]
    private BoxCollider2D BoxCollider2D;
    private Image Image;
    private bool IsOn = false;

    private void Awake()
    {
        TButton = GetComponent<Button>();
        TButton.onClick.AddListener(() => { OnClick(); });
        Image = GetComponent<Image>();
        Image.color = Color.red;
        BoxCollider2D.enabled = false;
    }
    private void OnClick()
    {
        if (IsOn)
        {
            IsOn = false;
            Image.color = Color.red;
            BoxCollider2D.enabled = false;
        }
        else
        {
            IsOn = true;
            Image.color = Color.green;
            BoxCollider2D.enabled = true;
        }
    }
}

