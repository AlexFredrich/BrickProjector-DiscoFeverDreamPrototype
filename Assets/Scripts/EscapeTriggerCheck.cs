using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeTriggerCheck : MonoBehaviour {


    [SerializeField]
    private GameObject EndingUI;

    [SerializeField]
    private Text endingMessage;

    int amount;

    GameObject pickupManager;
    PickupManager pickupManagerScript;
    private void Start()
    {
        pickupManager = GameObject.Find("PickupManager");
        pickupManagerScript = pickupManager.GetComponent<PickupManager>();
    }

    private void Update()
    {

        amount = pickupManagerScript.CollectedPickups;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && amount == 5)
        {
            EndingUI.SetActive(true);
            endingMessage.text = "Escape successful! The disco monster will dance alone tonight, awaiting his next victim. Thank goodness it's not you.";
        }
    }
}
