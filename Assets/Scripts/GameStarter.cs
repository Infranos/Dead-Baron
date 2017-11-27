using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour {

    void Update()
    {
        if (GameMenuVariables._atMainMenu && !CreditManager._atCreditScreen)
        {
            if (!GetComponent<Image>().enabled)
            {
                GetComponent<Image>().enabled = true;
                StartCoroutine(allowCollisions());
            }
        }
        else
        {
            GetComponent<Image>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private IEnumerator allowCollisions()
    {
        yield return new WaitForSeconds(2);
        GetComponent<Collider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "CandyCorn")
        {
            GameMenuVariables._atMainMenu = false;
            PlaneController._gameIsActive = true;
        }
    }
}
