using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuVariables : MonoBehaviour {
    //added _atDefaultMenu to seperate Main menu from other menus
    public static bool _atMainMenu, _atDefaultMenu;
    public GameObject _deadBaronTitle, _return, _music, _sound; 

	// Use this for initialization
	void Start () {
        _atMainMenu = true;
        _atDefaultMenu = true;
        _return.GetComponent<Image>().enabled = false;
        _music.GetComponent<Image>().enabled = false;
        _sound.GetComponent<Image>().enabled = false;
	}

    void Update()
    {
        if (_atMainMenu)
        {
            if (_atDefaultMenu) //added this if statement to check if the game is in the main menu or the options menu
            {
                _deadBaronTitle.GetComponent<SpriteRenderer>().enabled = true;
            }

            if (!GetComponent<AudioSource>().isPlaying)//this makes sure update doesnt play a bajillion tunes at once
            {
                GetComponent<AudioSource>().Play();//this starts the song whenever you enter the menu
            }
        }
        else
        {
            _deadBaronTitle.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<AudioSource>().Stop();//FIXME: Fade out or something
        }
    }
}
