using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour {
    public static int _highScore = 0;


    void Update() {
        if (GameMenuVariables._atMainMenu && !CreditManager._atCreditScreen)
            GetComponent<UnityEngine.UI.Text>().enabled = true;
        else
        {
            GetComponent<UnityEngine.UI.Text>().enabled = false;
            GetComponent<UnityEngine.UI.Text>().text = "Top Score: " + _highScore;
        }
        GetComponent<UnityEngine.UI.Text>().text = "Top Score: " + _highScore;
        if (ScoreManager._score > _highScore)
            _highScore = ScoreManager._score;
    }
}
