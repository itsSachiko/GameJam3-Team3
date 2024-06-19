using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPickable
{
    //classe per tutte le funzioni degli item
    public Transform myTransform { get => transform; set => myTransform = value; }
    public Item slot { get => this; set => slot = value; }
    public Action OnInteract { get; set; }
    public Action OnPickup { get ; set; }

    public Sprite image;

    private void OnEnable()
    {
        OnPickup += OnPickedUp;
        OnInteract += OnInteracted;
    }


    private void OnDisable()
    {
        OnPickup -= OnPickedUp;
        OnInteract -= OnInteracted;
    }
    private void OnInteracted()
    {
        InteractionTrigger.Interacted?.Invoke(this);
        OnPickup?.Invoke();
    }
    private void OnPickedUp()
    {
        Collider coll = GetComponent<Collider>();
        coll.enabled = false;
        Icon.OnIconDisabled?.Invoke();
    }

    //public void 
}
