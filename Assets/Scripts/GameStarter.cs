using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour {

    public GameObject _optionsStone;//this lets us get rid of the options menu later
    public GameObject _baronTitle;

    void Update()
    {
        if (GameMenuVariables._atMainMenu && GameMenuVariables._atDefaultMenu)
        {
            GetComponent<Image>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            _optionsStone.GetComponent<Image>().enabled = true;
        }
        //this logic means that when we leave default menu, the startstone automatically dissapears
        else
        {
            GetComponent<Image>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "CandyCorn")
        {
            GameMenuVariables._atMainMenu = false;
            PlaneController._gameIsActive = true;
            _optionsStone.GetComponent<Image>().enabled = false;//this statement removes the "options" stone when the start button is pushed
        }
    }
}
