using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditManager : MonoBehaviour
{

    public static bool _atCreditScreen = false;

    void Update()
    {
        if (GameMenuVariables._atMainMenu && !_atCreditScreen)
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
            _atCreditScreen = true;
        }
    }
}
