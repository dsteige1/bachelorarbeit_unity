using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{

    MeshRenderer Meshrenderer;
    public float originalSmoothness;

    void Start()
    {
        //Get the Renderer Component
        Meshrenderer = GetComponent<MeshRenderer>();
        //Get the original value to fall back to
        originalSmoothness = Meshrenderer.material.GetFloat("_Glossiness");
        //mats = Meshrenderer.materials;
    }

    public void ChangeGloss()
    {
        //Looping through material slots
        //With PointerEnter Trigger glossiness increases
        for (int i = 0; i < Meshrenderer.materials.Length; i++)
        {
            Meshrenderer.materials[i].SetFloat("_Glossiness", 1f);
        }
        //Meshrenderer.material.SetFloat("_Glossiness", 1f);
    }

    public void RestoreGloss()
    {
        //Fall back to original value on PointerExit Trigger
        for (int i = 0; i < Meshrenderer.materials.Length; i++)
        {
            Meshrenderer.materials[i].SetFloat("_Glossiness", originalSmoothness);
        }
        //Meshrenderer.material.SetFloat("_Glossiness", originalSmoothness);
    }
}
