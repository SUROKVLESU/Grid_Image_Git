using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private AndroidJavaClass MyAndroidJavaClass;
    public Text text1;
    public Text text2;
    public Text text3;


    public void OnFOO()
    {
        MyAndroidJavaClass = new AndroidJavaClass("com.example.mylibrarytest.PluginFolder");
        string str = MyAndroidJavaClass.CallStatic<string>("GetRootDirectory");
        string[] arrStr = MyAndroidJavaClass.CallStatic<string[]>("GetDirectories",str);
        string strName = MyAndroidJavaClass.CallStatic<string>("GetDirectoryName", arrStr[0]);

        text1.text = str;
        text3.text = strName;
        text2.text = "";
        for (int i = 1; i < arrStr.Length; i++)
        {
            text2.text += "("+arrStr[i]+")";
        }

        //Debug.Log(MyAndroidJavaClass);
        //image.color = new Color(Random.Range(30,155), 150, 80,255);
        //text.text = MyAndroidJavaClass.CallStatic<string>("Print");
        /*if (AndroidJavaClass.CallStatic<bool>("RaFolder"))
        {
            image.color = Color.red;

        }
        else
        {
            image.color = Color.green;
        }*/
        MyAndroidJavaClass.Dispose();
    }
}
