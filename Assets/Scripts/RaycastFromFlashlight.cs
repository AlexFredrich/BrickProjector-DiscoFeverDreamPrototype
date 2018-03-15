using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class RaycastFromFlashlight : MonoBehaviour
{
    [SerializeField]
    private float maxActivateDistance = 5.0f;

    public static bool isFlashlightOn = true;
    private bool isEthanStunned = false;

    [SerializeField]
    private float coolDown = 4f;

    private float timer;

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (isFlashlightOn && !isEthanStunned)
        {
            Debug.DrawRay(transform.position, transform.forward * maxActivateDistance);
            UpdateRaycast();
        }

        if(isEthanStunned)
        {
            StartCoroutine(EthanStunnedCooldown());
        }
        
	}

    private void UpdateRaycast()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, maxActivateDistance))
        {
            // if the raycast hits the enemy, make it stop moving
            if(hit.transform.tag == "Enemy")
            {
                //hit.rigidbody.isKinematic = false;
                AICharacterControl.isHitByFlashlight = true;
                isEthanStunned = true;
            }
        }
    }

    private IEnumerator EthanStunnedCooldown()
    {
        timer = 0f;

        while(!CoolDownTimer())
        {
            yield return null;
        }

        Debug.Log("Ethan is no longer stunned");
        AICharacterControl.isHitByFlashlight = false;
        isEthanStunned = false;
    }

    private bool CoolDownTimer()
    {
        timer += Time.deltaTime;
        if(timer<coolDown)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
