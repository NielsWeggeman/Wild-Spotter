
// *---- Purpose of this file: ----*
// Detect for how long a user has been looking at a button, and fire that
// button when a certain amount of time has passed.

// Based on the tutorial "Unity VR Tutorial - Button Gaze Timer Interaction"
// by 'Xlaughts' on youtube:
// https://www.youtube.com/watch?v=zdNBZsJdg9c

// The code sort of does the job, but only works when the player looks at
// the edge of the button.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GazeButton : MonoBehaviour
{
    public UnityEvent OVRClick;
    public float totalTime = 2;
    bool ovrStatus;
    public float ovrTimer;

    private void Update()
    {
        // if button is activated (gazed at), activate timer.
        if (ovrStatus)
        {
            ovrTimer += Time.deltaTime;
        }

        // (I experienced a bug with the menu in the Game Scene, which results
        //  in the 'back' button not sending the player back to the menu.
        //  Instead of using the 'Click event' to trigger the 'Menu controller'
        //  file which serves as the scene manager, I tried pulling this
        //  action forward and give this gaze button scene management access.
        //  However, for some reason the system still does not work.)

        Scene currentScene = SceneManager.GetActiveScene();

        // if timer runs out, fire the 'Click event' on the button
        if (ovrTimer > totalTime)
        {
            OVRClick.Invoke();

            // Based on the current scene name, the button decides on what
            // scene to send the user to.
            if (currentScene.name == "Menu")
            {
                SceneManager.LoadScene("Game");
            } else if (currentScene.name == "Game")
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    // OvrOn and OvrOff are the functions that get called based on the pointer
    // entering and leaving the ray collision detector. This information is
    // then used to start and reset the timer.
    public void OvrOn()
    {
        ovrStatus = true;
    }

    public void OvrOff()
    {
        ovrStatus = false;
        ovrTimer = 0;
    }


}
