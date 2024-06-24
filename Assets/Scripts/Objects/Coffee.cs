using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : Item, IPoisonable
{
    public bool isPoisoned { get; set; }
    public Transform poisonedTransform { get => transform; }
    Collider coll;

    int lastPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (isPoisoned)
        {
            if(other.transform.TryGetComponent(out NPCStateManager e))
            {
                e.death?.Invoke();
                isPoisoned = false;
            }
        }
        
    }

    protected override void Awake()
    {
        icon = GetComponent<Icon>();
        icon.OnIconChest?.Invoke(image);
        coll = GetComponent<Collider>();
    }

    protected override void OnEnable()
    {
        OnPickup += OnPickedUp;
        OnInteract += OnInteracted;
        OnUse += PutDown;
    }


    protected override void OnDisable()
    {
        OnPickup -= OnPickedUp;
        OnInteract -= OnInteracted;
        OnUse -= PutDown;
    }

    private void PutDown(int index)
    {

        transform.parent = null;
        if(Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
        {
            coll.enabled = true;
            Vector3 newPos = new(transform.position.x, hit.point.y + coll.bounds.extents.y, transform.position.z);

        }
        lastPosition = index;
        Inventory.OnItemRemoved?.Invoke(lastPosition);
    }

    protected override void OnInteracted(Inventory inv)
    {
        InteractionTrigger.Interacted?.Invoke(this);
        OnPickup?.Invoke();

    }
    protected override void OnPickedUp()
    {
        Collider coll = GetComponent<Collider>();
        coll.enabled = false;
        Icon.OnIconDisabled?.Invoke();
    }
}
