using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainScene : MonoBehaviour
{
    public Text bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        //LOAD HIGH SCORE
        //if you don't load on start, this UI wouldn't know what the high score is
        MainManager.instance.LoadHighScore();

        Debug.Log("High Score is " + MainManager.instance.highScore);
        //optional. It's here to let me check things work

        //DISPLAY HIGH SCORE AND PLAYER
        if (MainManager.instance != null)
        {
            if (MainManager.instance.highScore != 0)
            {
                DisplayHighScore();
            }
            else
            {
                DisplayName();
            }
        }
        else
        {
            bestScoreText.text = "Hello, set a high score!";
        }

       
    }

    void DisplayHighScore()
    {
        bestScoreText.text = MainManager.instance.playerName + ", can you beat the High Score " + MainManager.instance.highScore + " by " + MainManager.instance.highScoreName + "?";
    }

    void DisplayName()
    {
        bestScoreText.text = MainManager.instance.playerName + ", set a High Score!";
    }
}
