//Scripts and Technique found on Youtube https://www.youtube.com/watch?v=blO039OzUZc
//By Holistic3d, who is doing a great job explaining these functions

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMouse : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject player;

    void Start()
    {
        player = this.transform.parent.gameObject;
    }

    void Update()
    {
        //Getting coordinates from Cursor/Mouse-Position
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        //Locking the view angle from -80 to 80 degree on the y-axis
        mouseLook.y = Mathf.Clamp(mouseLook.y, -80f, 80f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);

    }
}
