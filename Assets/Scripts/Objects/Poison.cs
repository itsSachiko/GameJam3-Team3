using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : Item
{
    [SerializeField] float range;
    IPoisonable poisonedItem;
    protected override void Awake()
    {
        icon = GetComponent<Icon>();
        icon.OnIconChest?.Invoke(image);
    }

    protected override void OnEnable()
    {
        OnPickup += OnPickedUp;
        OnInteract += OnInteracted;
        OnUse += PoisonCoffee;
    }


    protected override void OnDisable()
    {
        OnPickup -= OnPickedUp;
        OnInteract -= OnInteracted;
        OnUse -= PoisonCoffee;
    }

    private void PoisonCoffee(int index)
    {
        float minDistance = 999f;
        Collider[] coll = Physics.OverlapSphere(transform.parent.position, range, 8);
        foreach (Collider collider in coll)
        {
            if (collider.TryGetComponent(out IPoisonable c))
            {
                float dist = Vector3.Distance(transform.parent.position, c.poisonedTransform.position);
                if (dist < minDistance)
                {
                    poisonedItem = c;
                    minDistance = dist;
                }
            }
        }

        poisonedItem.isPoisoned = true;
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
