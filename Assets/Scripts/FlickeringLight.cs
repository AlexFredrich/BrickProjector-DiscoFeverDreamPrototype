using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour {

    Light flickerLight;

    

    [SerializeField]
    float minWaitTime;
    [SerializeField]
    float maxWaitTime;

	// Use this for initialization
	void Start ()
    {
        
        flickerLight = GetComponent<Light>();
        StartCoroutine(Flashing());
        
	}
	
    IEnumerator Flashing()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            flickerLight.enabled = !flickerLight.enabled;
        }
    }
}
