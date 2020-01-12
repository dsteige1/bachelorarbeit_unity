//Technique found on Youtube https://www.youtube.com/watch?v=blO039OzUZc
//By Holistic3d

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    public float characterSpeed = 10.0F;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float translation   = Input.GetAxis("Vertical") * characterSpeed;
        float straffe       = Input.GetAxis("Horizontal") * characterSpeed;
        translation     *= Time.deltaTime;
        straffe         *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;

    }
}
