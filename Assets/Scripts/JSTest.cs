using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class JSTest : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void Hello();

    public void ClickForJS()
    {
        Debug.Log("Clicked");
        Hello();
    }
}
