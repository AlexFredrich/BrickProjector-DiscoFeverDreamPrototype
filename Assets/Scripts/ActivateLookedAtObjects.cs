using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateLookedAtObjects : MonoBehaviour 
{
    [SerializeField]
    private float maxActivateDistance = 6.0f;

    [SerializeField]
    private Text lookedAtObjectText;

    private IActivatable objectLookedAt;

    private int currentPickUpNumber;
    private int totalPickUpNumber = 5;
    private string itemMessage;

    void FixedUpdate ()
    {
        Debug.DrawRay(transform.position, transform.forward * maxActivateDistance);

        UpdateObjectLookedAt();
        UpdateLookedAtObjectText();
        ActivateLookedAtObject();
    }

    private void ActivateLookedAtObject()
    {
        if (objectLookedAt != null)
        {
            if (Input.GetButtonDown("Activate"))
            {
                objectLookedAt.DoActivate();
                currentPickUpNumber++;
                if(currentPickUpNumber < totalPickUpNumber)
                {
                    itemMessage = "You have collect: " + objectLookedAt.NameText + ". You have collected " + currentPickUpNumber + " out of " + totalPickUpNumber + " items.";
                }
                else
                {
                    itemMessage = "Escape";
                }
                lookedAtObjectText.text = itemMessage;

                StartCoroutine(FadeTextToFullAlpha(1f, lookedAtObjectText));
                StartCoroutine(FadeTextToZeroAlpha(1f, lookedAtObjectText));
            }
        }
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return new WaitForSeconds(1);
        }
    }

        private void UpdateLookedAtObjectText()
    {
        if (objectLookedAt != null)
            lookedAtObjectText.text = objectLookedAt.NameText;
        else
            lookedAtObjectText.text = "";
    }

    private void UpdateObjectLookedAt()
    {
        RaycastHit hit;
        objectLookedAt = null;

        if (Physics.Raycast(transform.position, transform.forward, out hit, maxActivateDistance))
        {
            objectLookedAt = hit.transform.GetComponent<IActivatable>();
        }
    }
}
