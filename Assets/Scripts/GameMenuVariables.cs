using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuVariables : MonoBehaviour
{
    public static bool _atMainMenu;
    public GameObject _deadBaronTitle, _movementControlInfo, _fireControlInfo;
    public AudioClip _menuTune, _levelTune;

    // Use this for initialization
    void Start()
    {
        _atMainMenu = true;
    }

    void Update()
    {
        if (_atMainMenu)
        {
            if (CreditManager._atCreditScreen)
            {
                _deadBaronTitle.GetComponent<SpriteRenderer>().enabled = false;
                _movementControlInfo.GetComponent<SpriteRenderer>().enabled = false;
                _fireControlInfo.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
                _deadBaronTitle.GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<AudioSource>().clip = _menuTune;
        }
        else
        {
            _deadBaronTitle.GetComponent<SpriteRenderer>().enabled = false;
            _movementControlInfo.GetComponent<SpriteRenderer>().enabled = false;
            _fireControlInfo.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<AudioSource>().clip = _levelTune;
        }
        audioUpdate();
    }

    private void audioUpdate()
    {
        if (_atMainMenu)
        {
            if (HighScoreManager._highScore > 10000)
                GetComponent<AudioSource>().pitch = 1;
            else if (HighScoreManager._highScore > 8000)
                GetComponent<AudioSource>().pitch = 0.5f;
            else if (HighScoreManager._highScore > 6000)
                GetComponent<AudioSource>().pitch = 0.3f;
            else if (HighScoreManager._highScore > 4000)
                GetComponent<AudioSource>().pitch = 0.2f;
            else if (HighScoreManager._highScore > 2000)
                GetComponent<AudioSource>().pitch = 0.15f;
            else
                GetComponent<AudioSource>().pitch = -0.1f;
        }
        else
        {
            GetComponent<AudioSource>().pitch = 1;
        }

        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
