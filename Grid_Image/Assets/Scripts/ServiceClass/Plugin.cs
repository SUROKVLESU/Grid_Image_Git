using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Plugin : MonoBehaviour
{
    public static AndroidJavaClass PluginFolder;
    private void Awake()
    {
        PluginFolder = new AndroidJavaClass("com.example.mylibrarytest.PluginFolder");
    }
}

