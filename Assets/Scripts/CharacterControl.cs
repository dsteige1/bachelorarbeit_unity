//Technique found on Youtube https://www.youtube.com/watch?v=blO039OzUZc
//By Holistic3d

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControl : MonoBehaviour
{

    public float characterSpeed = 10.0F;
    private bool cursorLockState = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    /* */

    void Update()
    {
        /*
         * Get Arrow-keys inputs and give them to transform-component
         * multiply by Time.deltaTime, in order to ignore the framerate of the machine
         * it's running on
        */

        float translation = Input.GetAxis("Vertical") * characterSpeed;
        float straffe = Input.GetAxis("Horizontal") * characterSpeed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        /* Catch a fall 'off the world' in case I missed a collider somewhere */

        if (transform.position.y < (-10))
            SceneManager.LoadScene("MainScene");

        /* Check if the Cursor is locked / made invisible
         * If so unlock to be able to interact / trigger
         * If not: Lock it, so the cursor cannot leave the game window
         * The cursor will be locked in the middle of the window, so everytime
         * the curdot gets unlocked, it'll appear in the center, which makes it easier to find 
         * and to navigate / interact with the objects.
        */

        if (Input.GetKeyDown("space"))
        {
            if (cursorLockState)
            {
                Cursor.lockState = CursorLockMode.Locked;
                cursorLockState = false;
            }
            else if (cursorLockState == false)
            {
                Cursor.lockState = CursorLockMode.None;
                cursorLockState = true;
            }
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            cursorLockState = true;
        }
    }
}