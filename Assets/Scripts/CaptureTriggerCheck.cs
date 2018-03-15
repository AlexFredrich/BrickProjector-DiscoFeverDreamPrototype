using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureTriggerCheck : MonoBehaviour {

    [SerializeField]
    private GameObject EndingUI;

    [SerializeField]
    private Text endingMessage;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            EndingUI.SetActive(true);
            endingMessage.text = "You were caught by the disco monster. Forced to dance the night away for all of eternity.";

        }
    }
}
