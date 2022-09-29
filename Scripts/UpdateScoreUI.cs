// *---- Purpose of this file: ----*
// Pass on the upgraded value from the 'Gaze Interactor' to the user UI.
// I also use this code to play the confirming 'coin' sound once the user has
// spotted an animal.

// Based on the tutorial "How to update UI (user interface) text game object
// component via script in 2D Unity game?" by 'Alexander Zotov' on youtube:
// https://www.youtube.com/watch?v=45U3PhmUSuI

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class UpdateScoreUI : MonoBehaviour
{

    public TextMeshProUGUI animalCounter;
    public int score;
    public int oldScore;
    public int amountOfAnimals = 7;

    public AudioClip coin;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = coin;
        animalCounter = gameObject.GetComponent<TextMeshProUGUI>();
        score = 0;
    }

    void Update()
    {
        // This small code set up plays the coin sound only once when an
        // animal has been spotted.
        if (score > oldScore)
            GetComponent<AudioSource>().Play();
        animalCounter.text = score.ToString()+"/"+amountOfAnimals;
        oldScore = score;

        // If all animals have been spotted, the UI gets update to congratulate
        // the player.
        if(score == amountOfAnimals)
        {
            animalCounter.fontSize = 50;
            animalCounter.text = "Congratulations, you found them all!";
        }
    }
}
