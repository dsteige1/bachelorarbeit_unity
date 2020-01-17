﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float RotateSpeed = 50f;

    void Update()
    {
        transform.Rotate(0,0,RotateSpeed * Time.deltaTime);
    }
}