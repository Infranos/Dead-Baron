using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnScript : MonoBehaviour {

    public GameObject _baronTitle, _optionsBubble, _returnBubble, _soundBubble, _musicBubble;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "CandyCorn")
        {
            if (!GameMenuVariables._atDefaultMenu)//this if statement makes it so the return only happens when we arent in the deafulat menu
            {
                GameMenuVariables._atDefaultMenu = true;


                //this brings the title of the game back to the screen
                _baronTitle.GetComponent<SpriteRenderer>().enabled = true;


                //the "options" stone is brought back out by this statement, the "Breath Again" stone is knocked out via logic(seeGameStarter Script)
                _optionsBubble.GetComponent<Image>().enabled = true;


                //these stones are placed on screen by the trigger
                _returnBubble.GetComponent<Image>().enabled = false;
                _soundBubble.GetComponent<Image>().enabled = false;
                _musicBubble.GetComponent<Image>().enabled = false;
            }
        }
    }

}
