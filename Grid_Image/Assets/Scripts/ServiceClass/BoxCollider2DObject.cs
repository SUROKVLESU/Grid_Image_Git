using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

public class BoxCollider2DObject : MonoBehaviour 
{
    public int index;
    public GameObject GameObject;
    private BoxCollider2D BoxCollider;
    public BoxCollider2DObject(Image ImageObject,CubicKangeFilled cubic,int index,Sprite sprite)
    {
        if (ImageObject.rectTransform.localRotation.z >0.1)
        {
            this.index = index;
            Image image = ImageObject.GetComponent<Image>();
            float width = image.rectTransform.rect.height;
            float height = image.rectTransform.rect.width;
            GameObject GridObject = ImageObject.rectTransform.GetChild(0).gameObject;
            RectTransform GridRectTransform = GridObject.GetComponent<RectTransform>();
            GridRectTransform.localPosition = new Vector3(0, 0, 0);
            GridRectTransform.localRotation = Quaternion.Euler(180,0,-90);
            GameObject = new GameObject("BoBoxCollider2DObject" + index);
            Destroy(GameObject.GetComponent<Transform>());
            RectTransform rectTransform = GameObject.AddComponent<RectTransform>(); ;
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            //rectTransform.rotation = ImageObject.transform.rotation;
            rectTransform.parent = GridObject.transform;
            rectTransform.localScale = new Vector3(1, 1, 1);
            //rectTransform.localRotation = Quaternion.Euler(0, 0, 0);
            BoxCollider = GameObject.AddComponent<BoxCollider2D>();
            BoxCollider.isTrigger = true;
            BoxCollider.size =
                new Vector2(width * ((cubic.RightX - cubic.LeftX) / 100f),
                    height * ((cubic.LeftY - cubic.RightY) / 100f));
            rectTransform.localPosition =
                new Vector3((float)cubic.RightX / 100 * width - //x
                    (float)(cubic.RightX - cubic.LeftX) / 200 * width,
                (float)cubic.LeftY / 100 * height -//y
                    (float)(cubic.LeftY - cubic.RightY) / 200 * height, 0);
            rectTransform.localPosition =
                new Vector3(rectTransform.localPosition.x - width / 2
                    , rectTransform.localPosition.y - height / 2
                        , rectTransform.localPosition.z);
            Image BoxImage = GameObject.AddComponent<Image>();
            BoxImage.overrideSprite = sprite;
            BoxImage.rectTransform.SetSizeWithCurrentAnchors
                        (RectTransform.Axis.Vertical, BoxCollider.size.y);
            BoxImage.rectTransform.SetSizeWithCurrentAnchors
                (RectTransform.Axis.Horizontal, BoxCollider.size.x);
        }
        else
        {
            this.index = index;
            Image image = ImageObject.GetComponent<Image>();
            float width = image.rectTransform.rect.height;
            float height = image.rectTransform.rect.width;
            GameObject GridObject = ImageObject.rectTransform.GetChild(0).gameObject;
            RectTransform GridRectTransform = GridObject.GetComponent<RectTransform>();
            GridRectTransform.localPosition = new Vector3(0, 0, 0);
            GridRectTransform.localRotation = Quaternion.Euler(0, 0, 0);
            GameObject = new GameObject("BoBoxCollider2DObject" + index);
            Destroy(GameObject.GetComponent<Transform>());
            RectTransform rectTransform = GameObject.AddComponent<RectTransform>(); ;
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            //rectTransform.rotation = ImageObject.transform.rotation;
            rectTransform.parent = GridObject.transform;
            rectTransform.localScale = new Vector3(1, 1, 1);
            //rectTransform.localRotation = Quaternion.Euler(0, 0, 0);
            BoxCollider = GameObject.AddComponent<BoxCollider2D>();
            BoxCollider.isTrigger = true;
            BoxCollider.size =
                new Vector2(width * ((cubic.RightX - cubic.LeftX) / 100f),
                    height * ((cubic.LeftY - cubic.RightY) / 100f));
            rectTransform.localPosition =
                new Vector3((float)cubic.RightX / 100 * width - //x
                    (float)(cubic.RightX - cubic.LeftX) / 200 * width,
                (float)cubic.LeftY / 100 * height -//y
                    (float)(cubic.LeftY - cubic.RightY) / 200 * height, 0);
            rectTransform.localPosition =
                new Vector3(rectTransform.localPosition.x - width / 2
                    , rectTransform.localPosition.y - height / 2
                        , rectTransform.localPosition.z);
            Image BoxImage = GameObject.AddComponent<Image>();
            BoxImage.overrideSprite = sprite;
            BoxImage.rectTransform.SetSizeWithCurrentAnchors
                        (RectTransform.Axis.Vertical, BoxCollider.size.y);
            BoxImage.rectTransform.SetSizeWithCurrentAnchors
                (RectTransform.Axis.Horizontal, BoxCollider.size.x);
            GridRectTransform.localRotation = Quaternion.Euler(180, 0, -90);
        }
    }
}

