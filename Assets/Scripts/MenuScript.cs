using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class MenuScript : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void TutAnchor();

    public void StartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AnchorClick()
    {
        Debug.Log("Anchor should be called.");
        TutAnchor();
    }
}
