using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class RGBValue : MonoBehaviour 
{
    public float Value;
    private const float CONST_multiplier = 0.001f/3;
    private Text Text;
    private RectTransform BoxCollider2D;
    private RectTransform RectTransform;
    private RectTransform RectTransformParent;
    private void Awake()
    {
        Text = transform.GetChild(0).GetComponentInChildren<Text>();
        BoxCollider2D = GetComponent<RectTransform>();
        RectTransform = transform.GetChild(0).GetComponent<RectTransform>();
        RectTransformParent = transform.parent.GetComponent<RectTransform>();
        BoxCollider2D boxCollider = BoxCollider2D.GetComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(BoxCollider2D.rect.width- RectTransform.rect.width, BoxCollider2D.rect.height);
        //RectTransform RectTransformParent = transform.parent.GetComponent<RectTransform>();
        //GetComponent<BoxCollider2D>().offset = new Vector2(0,0);

    }
    void OnMouseDrag()
    {

        Vector3 vector = Input.mousePosition;
        float vectorX;
        if (BoxCollider2D.position.x < 0)
        {
            vectorX = vector.x - RectTransform.rect.width;
        }
        else
        {
            vectorX = vector.x
                - RectTransformParent.rect.width / 2
                - (RectTransformParent.rect.width / 2 - BoxCollider2D.rect.width)
                - RectTransform.rect.width;
        }
        float vectorXC = -(BoxCollider2D.rect.width - RectTransform.rect.width) / 2 + vectorX;
        Value += vectorXC * Time.deltaTime * CONST_multiplier;
        Text.text = Value.ToString();
        if (Value > 1) { Value = 1; }
        if (Value < -1) { Value = -1; }
        Controller.ShiftRGB();
    }
    public void SetText() { Text.text = Value.ToString(); }
}
