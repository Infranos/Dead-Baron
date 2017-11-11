using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsStarter : MonoBehaviour {

    public GameObject _baronTitle, _startBubble, _optionsBubble;//this script will make the title and option stones dissapear
    public GameObject _returnBubble, _soundBubble, _musicBubble;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "CandyCorn")
        {
            //this if statement makes sure the options menu is only opened if we were at the main menu and not in the options menu
            if (GameMenuVariables._atDefaultMenu && GameMenuVariables._atMainMenu)
            {
                GameMenuVariables._atDefaultMenu = false;

                //this removes the title of the game from the screen
                _baronTitle.GetComponent<SpriteRenderer>().enabled = false;

                //the "options" stone is knocked out by this statement, the "Breath Again" stone is knocked out via logic(seeGameStarter Script)
                _optionsBubble.GetComponent<Image>().enabled = false;


                //these stones are placed on screen by the trigger
                _returnBubble.GetComponent<Image>().enabled = true;
                _soundBubble.GetComponent<Image>().enabled = true;
                _musicBubble.GetComponent<Image>().enabled = true;
            }
        }
    }
}
