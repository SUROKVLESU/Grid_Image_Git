using UnityEngine;
using UnityEngine.UI;

public class ButtonBoxCollider : MonoBehaviour
{
    public int index;
    public Image image;
    void OnMouseUp()
    {
        Controller.SetActiveRGB(true);
        Controller.SetSelectedBoxCollider(index);
        Controller.SetImageCubic(image);
    }
}
