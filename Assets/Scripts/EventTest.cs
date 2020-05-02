using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    public bool eventHit = false;

    public void TestEvent()
    {
        Debug.Log("Der Hit!");
        eventHit = true;
    }
}