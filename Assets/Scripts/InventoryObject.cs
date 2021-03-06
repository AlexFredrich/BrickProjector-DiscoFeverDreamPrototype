﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryObject : MonoBehaviour, IActivatable
{
    [SerializeField]
    private string nameText;

    [SerializeField]
    private string descriptionText;

    [SerializeField]
    private Light light;


    Text itemText;

    private AudioSource audioSource;
    private MeshRenderer meshRenderer;
    private MeshRenderer[] childRenderers;
    private Collider collider;
    bool isCollected_UseProperty;
    int amount;
    string itemMessage;
    PickupManager pickupManagerScript;

    public bool IsCollected
    {
        get { return isCollected_UseProperty; }
        private set { isCollected_UseProperty = value; }
    }

    public string NameText
    {
        get
        {
            return nameText;
        }
    }

    public string DescriptionText { get { return descriptionText; } }

    public void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
        childRenderers = GetComponentsInChildren<MeshRenderer>();
        descriptionText = descriptionText.Replace("\\n", "\n");
        audioSource = GetComponent<AudioSource>();
        GameObject pickUpManager = GameObject.Find("PickupManager");
        pickupManagerScript = pickUpManager.GetComponent<PickupManager>();

        
    }
    public void DoActivate()
    {
        audioSource.Play();
        // Doing this rather than destroy because our Inventory menu still needs
        // to know about this object even though it has been collected and 
        // removed from the 3D world.
        // Also, if you wanted to add sound effects here,
        // and we destroy before the sfx are done, it will not sound correct.
        // Just like how coin worked in our 2D project!
        if (light != null)
            light.enabled = false;
        if (meshRenderer != null)
            meshRenderer.enabled = false;
        if (childRenderers != null)
            foreach (MeshRenderer r in childRenderers)
                r.enabled = false;
        collider.enabled = false;
        IsCollected = true;
        pickupManagerScript.UpdateText();


    }
 
}