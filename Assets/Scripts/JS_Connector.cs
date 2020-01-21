using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class JS_Connector : MonoBehaviour
{

    //Import JS-functions from local library (myLib.jslib)

    [DllImport("__Internal")]
    private static extern void SendObjName(string myVar);

    public void ClickForJS()
    {
        //Debug.Log(this.gameObject.name);
        SendObjName(this.gameObject.name);
    }
}
