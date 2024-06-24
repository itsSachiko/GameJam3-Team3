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
    public Action<Inventory> OnInteract { get; set; }
    public Action OnPickup { get ; set; }

    public Action OnCompletedInteraction { get; set; }

    public Action<int> OnUse { get; set; }

    public Sprite image;

    protected Icon icon;

    protected virtual void Awake()
    {
        icon = GetComponent<Icon>();
        icon.OnIconChest?.Invoke(image);
    }

    protected virtual void OnEnable()
    {
        OnPickup += OnPickedUp;
        OnInteract += OnInteracted;
    }


    protected virtual void OnDisable()
    {
        OnPickup -= OnPickedUp;
        OnInteract -= OnInteracted;
    }
    protected virtual void OnInteracted(Inventory inv)
    {
        InteractionTrigger.Interacted?.Invoke(this);
        OnPickup?.Invoke();
       
    }
    protected virtual void OnPickedUp()
    {
        Collider coll = GetComponent<Collider>();
        coll.enabled = false;
        Icon.OnIconDisabled?.Invoke();
    }


    //public void 
}
