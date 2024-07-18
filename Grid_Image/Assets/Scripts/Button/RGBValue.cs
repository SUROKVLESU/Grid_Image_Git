using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class RGBValue : MonoBehaviour 
{
    public float Value;
    private const float CONST_Ьultiplier = 0.001f;
    private Text Text;
    private RectTransform BoxCollider2D;
    private RectTransform RectTransform;
    private void Awake()
    {
        Text = transform.parent.GetComponentInChildren<Text>();
        BoxCollider2D = GetComponent<RectTransform>();
        RectTransform = transform.parent.GetComponent<RectTransform>();
        BoxCollider2D boxCollider = BoxCollider2D.GetComponent<BoxCollider2D>();
        boxCollider.size = BoxCollider2D.sizeDelta;
    }
    void OnMouseDrag()
    {
        if(RectTransform.localRotation.eulerAngles.z > 0)
        {
            Vector3 vector = Input.mousePosition;
            float vectorX = vector.y - BoxCollider2D.rect.height;
            float vectorXC = -BoxCollider2D.rect.width / 2 + vectorX;
            Value -= vectorXC * Time.deltaTime* CONST_Ьultiplier;
            Text.text = Value.ToString();
        }
        else
        {
            Vector3 vector = Input.mousePosition;
            float vectorX =vector.x-(RectTransform.rect.width-BoxCollider2D.rect.width);
            float vectorXC = -BoxCollider2D.rect.width / 2 + vectorX;
            Value += vectorXC * Time.deltaTime* CONST_Ьultiplier;
            Text.text = Value.ToString();
        }
        Controller.ShiftRGB();
        if (Value > 1) { Value = 1; }
        if (Value < 0) { Value = 0; }
        Controller.ShiftRGB();
    }
    public void SetText() { Text.text = Value.ToString(); }
}
