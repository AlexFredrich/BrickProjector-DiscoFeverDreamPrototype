using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupManager : MonoBehaviour 
{
    // SerializeFields for assignment in-editor
    /// <summary>
    /// Prefabs of pickups to use throughout the stage
    /// </summary>
    [Tooltip("List of pickup prefabs")]
    [SerializeField]
    List<GameObject> pickupPrefabs;
    /// <summary>
    /// Pickup spawn points
    /// </summary>
    [Tooltip("List of pickup spawn points")]
    [SerializeField]
    List<Transform> pickupSpawns;
    //[SerializeField] Text pickupText;

    // Private fields
    /// <summary>
    /// Number of pickups collected
    /// </summary>
    int collectedPickups;
    /// <summary>
    /// List of pickups placed in-game
    /// </summary>
    List<GameObject> activePickups = new List<GameObject>();


    // Use this for initialization
    void Start () 
	{
        PlacePickups();
        StartCoroutine(CheckPickups());
	}

    private void Update()
    {
        //if(pickupText != null)
        //    UpdateText();
    }

    /// <summary>
    /// Place pickups at spawn points
    /// </summary>
    void PlacePickups()
    {
        int spawnPoint = 0;
        foreach(GameObject go in pickupPrefabs)
        {
            spawnPoint = Random.Range(0, pickupSpawns.Count);
            GameObject tempPickup = Instantiate(go);
            tempPickup.transform.position = pickupSpawns[spawnPoint].position;
            activePickups.Add(tempPickup);
            pickupSpawns.Remove(pickupSpawns[spawnPoint]);
        }
    }
    
    /// <summary>
    /// Update content of the text object.
    /// Function used for testing
    /// </summary>
    /*void UpdateText()
    {
        if (collectedPickups < pickupPrefabs.Count)
            pickupText.text = "Pickups Collected: " + collectedPickups;
        else
            pickupText.text = "All pickups collected.";
    }*/

    /// <summary>
    /// Check each pickup to determine whether or not it has been collected
    /// </summary>
    /// <returns></returns>
    IEnumerator CheckPickups()
    {
        while(collectedPickups < pickupPrefabs.Count)
        {
            for(int i = 0; i < activePickups.Count; i++)
                if(activePickups[i].GetComponent<InventoryObject>().IsCollected)
                {
                    collectedPickups++;
                    activePickups.Remove(activePickups[i]);
                    i--;
                }
            yield return null;
        }
    }
}
