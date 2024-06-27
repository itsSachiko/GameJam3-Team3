using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IChest
{
    public Transform myTransform { get => transform; set => myTransform = value; }
    public IPickable pickable { get; set; }
    public Action<Inventory> OnInteract { get; set; }

    MeshRenderer pickableRenderer;
    public Action OnCompletedInteraction { get; set; }

    Icon icon;

    Sprite s;

    private void Awake()
    {
        icon = GetComponent<Icon>();
    }

    private void OnEnable()
    {
        OnInteract += OnInteracted;
       
    }

    private void OnDisable()
    {
        OnInteract -= OnInteracted;
       
    }

    private void CompletedInteraction()
    {
        //pickableRenderer.enabled = true;
        pickable.OnCompletedInteraction -= CompletedInteraction;
        pickable = null;
        icon.OnIconChest?.Invoke(null);
    }

    private void OnInteracted(Inventory inv)
    {
        if (pickable != null)
        {
            pickable.OnInteract?.Invoke(inv);
            
            return;
        }
        if (inv.inventory[inv.currentInvSlot] == null)
        {
            return;
        }
        pickable = inv.inventory[inv.currentInvSlot];
        InventoryUI.getImage?.Invoke(inv.currentInvSlot, out s);
        icon.OnIconChest?.Invoke(s);


        pickable.OnCompletedInteraction += CompletedInteraction;
        inv.inventory[inv.currentInvSlot] = null;
        pickable.myTransform.parent = transform;
        pickable.myTransform.TryGetComponent(out pickableRenderer);
        //pickableRenderer.enabled = false;
        Inventory.OnInventoryChanged?.Invoke(null, inv.currentInvSlot);
    }
}
