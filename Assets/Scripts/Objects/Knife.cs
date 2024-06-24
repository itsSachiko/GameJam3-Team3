using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Item, IDangerous
{
    [SerializeField]float range = 1f;
    NPCStateManager enemy;
    protected override void Awake()
    {
        icon = GetComponent<Icon>();
        icon.OnIconChest?.Invoke(image);
    }

    protected override void OnEnable()
    {
        OnPickup += OnPickedUp;
        OnInteract += OnInteracted;
        OnUse += Kill;
    }


    protected override void OnDisable()
    {
        OnPickup -= OnPickedUp;
        OnInteract -= OnInteracted;
        OnUse -= Kill;
    }

    private void Kill(int index)
    {
        float minDistance = 999f;
        Collider[] coll = Physics.OverlapSphere(transform.parent.position, range, 8);
        foreach (Collider collider in coll)
        {
            if (collider.TryGetComponent(out NPCStateManager e))
            {
                float dist = Vector3.Distance(transform.parent.position, e.transform.position);
                if ( dist < minDistance)
                {
                    enemy = e;
                    minDistance = dist; 
                }
            }
        }
        enemy.death?.Invoke();
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

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
#endif
}
