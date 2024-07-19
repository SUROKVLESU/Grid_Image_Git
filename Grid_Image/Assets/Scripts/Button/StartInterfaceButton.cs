using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

internal class StartInterfaceButton : MonoBehaviour
{
    [SerializeField]
    private GameObject File_ControllerObj;
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(()=>
        {
            OnClick();
        });
    }
    private void OnClick()
    {
        if (Plugin.PluginFolder.CallStatic<bool>("IsAccessToMemory"))
        {
            transform.parent.gameObject.SetActive(false);
            File_ControllerObj.SetActive(true);
        }
    }
}

