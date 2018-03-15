using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeTriggerCheck : MonoBehaviour {


    [SerializeField]
    private GameObject EndingUI;

    [SerializeField]
    private Text endingMessage;

    [SerializeField]
    private GameObject pickupManager;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            EndingUI.SetActive(true);
            endingMessage.text = "Escape successful! The disco monster will dance alone tonight, awaiting his next victim. Thank goodness it's not you.";
        }
    }
}
