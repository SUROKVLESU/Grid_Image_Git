using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SaveImageButton : MonoBehaviour
{
    private Button SaveButton;
    private Image ImageButton;
    private Color Color;

    public UnityAction OnClickSaveButton;

    public void ButtonInitialization()
    {
        SaveButton = 
            this.gameObject.transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Button>();
        ImageButton = 
            this.gameObject.transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>();
        Color = ImageButton.color;
        SaveButton.onClick.RemoveAllListeners();
        SaveButton.onClick.AddListener(() => { OnClickSaveButton(); });
    }
    public void OffSaveButton()
    {
        ImageButton.color = Color.red;
        SaveButton.enabled = false;
    }public void OnSaveButton()
    {
        ImageButton.color = Color;
        SaveButton.enabled= false;
    }
    public void OnImageSaveButton(Texture2D texture)
    {
        ImageButton.color = Color.green;
        SaveButton.enabled = true;
    }
}
