using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Works like a charm
public class PausingGame : MonoBehaviour
{
    public enum State
    {
        pause,
        playing
    };

    State gameState = State.playing;
    float timeScaleBeforePause;

    public State getGameState()
    {
        return gameState;
    }

    // Update is called once per frame
    void Update()
    {
        //timeScale!=0 basically
        if (Input.GetKeyDown(KeyCode.Escape)
            && gameState == State.playing)
        {
            gameState = State.pause;
            timeScaleBeforePause = Time.timeScale;
            Time.timeScale = 0;
            //display your pause GUI
        }

        else if (Input.GetKeyDown(KeyCode.Escape)
             && gameState == State.pause)
        {
            gameState = State.playing;
            Time.timeScale = timeScaleBeforePause;
        }
    }
}
