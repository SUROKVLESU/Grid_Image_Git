using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleImage : MonoBehaviour
{
    private Button Button;
    private Text Text;
    [SerializeField]
    private Image SceneScaleImage;
    [SerializeField]
    private Transform TransformCamera;
    int Condition = 0;
    private void Awake()
    {
        Button = GetComponent<Button>(); 
        Text = GetComponentInChildren<Text>();
        Button.onClick.AddListener(() => { OnClic(); });
    }
    private void OnClic()
    {
        if (Condition == 5) Condition = 0;
        else Condition++;
        SceneScaleImage.rectTransform.localScale = new Vector3(0.5f + 0.1f * Condition, 0.5f + 0.1f * Condition, 1);
        int IntText = 0 + 20*Condition;
        Text.text = IntText.ToString()+"%";
        if(Condition == 0)
        {
            TransformCamera.position = new Vector3(0, 0, TransformCamera.position.z);
        }
    }
}
