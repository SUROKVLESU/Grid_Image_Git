using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControllerCamera : MonoBehaviour , IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private Image ScaleImage;
    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _camera.transform.position = eventData.pointerPressRaycast.worldPosition;
        _camera.transform.position = 
            new Vector3(_camera.transform.position.x, _camera.transform.position.y,-10);
    }
}
