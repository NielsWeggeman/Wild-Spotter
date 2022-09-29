// *---- Purpose of this file: ----*
// Manage to which scene the user gets send, depending on what button is
// pressed.

// Based on the tutorial "Unity VR Development for Oculus Quest: Main Menu"
// by 'Realary' on youtube:
// https://www.youtube.com/watch?v=Xhz7cW5dbyY&t=73s

// For some reason, the 'MenuBtn' does not work. This probably has something
// to do with the way it is currently set up in the Unity editor.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("Game");
    }

    public void MenuBtn()
    {
        SceneManager.LoadScene("Menu");
    }
}
