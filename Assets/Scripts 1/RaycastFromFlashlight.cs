using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastFromFlashlight : MonoBehaviour
{
    [SerializeField]
    private float maxActivateDistance = 5.0f;
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        UpdateRaycast();
	}

    private void UpdateRaycast()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, maxActivateDistance))
        {
            // if the raycast hits the enemy, make it stop moving
            if(hit.transform.tag == "Enemy")
            {
                hit.rigidbody.isKinematic = false;
            }
        }
    }
}
