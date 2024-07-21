using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControllerCamera : MonoBehaviour 
{
    [SerializeField]
    private Camera _camera;
    private Vector3 _position;

    private void Awake()
    {
        RectTransform rectTransform = transform.parent.GetComponent<RectTransform>();
        GetComponent<BoxCollider2D>().size = rectTransform.sizeDelta;
        GetComponent<RectTransform>().position = new Vector3(0, 0, rectTransform.position.z);

    }
    void OnMouseDrag()
    {
        _position = _camera.transform.position;
        Vector3 point = 
            _camera.ScreenToWorldPoint
                (new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.transform.position.z));
        point = _position-point;
        _camera.transform.position -=
            new Vector3(point.x*Time.deltaTime, point.y * Time.deltaTime,0);
        if(_camera.transform.position.x<-25|| _camera.transform.position.x>25||
            _camera.transform.position.y<-15|| _camera.transform.position.y>15)
        {
            _camera.transform.position=_position;
        }
    }
}
