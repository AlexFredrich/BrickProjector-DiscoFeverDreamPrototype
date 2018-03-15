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
    [SerializeField] Text pickupText;

    // Private fields
    /// <summary>
    /// Number of pickups collected
    /// </summary>
    
    /// <summary>
    /// List of pickups placed in-game
    /// </summary>
    List<GameObject> activePickups = new List<GameObject>();
    int collectedPickups_UseProperty;
    string itemMessage;

    public int CollectedPickups
    {
        get { return collectedPickups_UseProperty; }
        set { collectedPickups_UseProperty = value; }
    }


    // Use this for initialization
    void Start () 
	{
        PlacePickups();
        StartCoroutine(CheckPickups());

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
    
    // <summary>
    // Update content of the text object.
    // Function used for testing
    /// </summary>
    public void UpdateText()
    {
        if (CollectedPickups < 5)
        {
            itemMessage = "You have collected " + CollectedPickups + " out of 5 items.";
        }
        else
        {
            itemMessage = "Escape";
        }
      

        StartCoroutine(FadeTextToFullAlpha(1f, pickupText));
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.text = itemMessage;
        /*Color startColor = new Color(i.color.r, i.color.g, i.color.b, 0);
        Color fullAlpha = new Color(i.color.r, i.color.g, i.color.b, 1f);
        while (i.color.a < 1.0f)
        {
            i.color = Color.Lerp(startColor, fullAlpha, 2.5f);
            yield return null;
        }*/
        i.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);

        StartCoroutine(FadeTextToZeroAlpha(1f, pickupText));
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.text = itemMessage;
        /*Color startColor = new Color(i.color.r, i.color.g, i.color.b, 1);
        Color noAlpha = new Color(i.color.r, i.color.g, i.color.b, 0f);
        while (i.color.a > 0.0f)
        {
            i.color = Color.Lerp(startColor, noAlpha, 2.5f);
            yield return new WaitForSeconds(1);
        }*/
        i.gameObject.SetActive(false);
        yield return null;
    }

    /// <summary>
    /// Check each pickup to determine whether or not it has been collected
    /// </summary>
    /// <returns></returns>
    IEnumerator CheckPickups()
    {
        while(CollectedPickups < pickupPrefabs.Count)
        {
            for(int i = 0; i < activePickups.Count; i++)
                if(activePickups[i].GetComponent<InventoryObject>().IsCollected)
                {
                    CollectedPickups++;
                    activePickups.Remove(activePickups[i]);
                    i--;
                }
            yield return null;
        }
    }
}
