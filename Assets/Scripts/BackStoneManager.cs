using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackStoneManager : MonoBehaviour {

    public Image _creditScreen;

	void Update () {
		if (CreditManager._atCreditScreen)
        {
            if (!GetComponent<Image>().enabled)
            {
                _creditScreen.enabled = true;
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
            CreditManager._atCreditScreen = false;
            _creditScreen.enabled = false;
        }
    }
}
