using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class JSTest : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Hello(string myVar);

    public void ClickForJS()
    {
        Debug.Log(this.gameObject.name);
        Hello(this.gameObject.name);
    }
}
