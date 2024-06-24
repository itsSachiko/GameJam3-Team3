using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public Transform myTransform { get; set; }
    public Action<Inventory> OnInteract { get; set; }

    public Action OnCompletedInteraction { get; set; }
}

public interface IPickable : IInteractable
{
    public Item slot { get; set; }
    public Action OnPickup {  get; set; }

    public Action<int> OnUse { get; set; }
}

public interface IChest : IInteractable
{
    public IPickable pickable { get; set; }
}