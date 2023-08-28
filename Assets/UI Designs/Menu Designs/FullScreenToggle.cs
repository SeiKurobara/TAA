using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenToggle : MonoBehaviour
{
public void FullScene(bool is_FullScene)
    {
        Screen.fullScreen = is_FullScene;
        Debug.Log("FullScreen" + is_FullScene);
    }
}
