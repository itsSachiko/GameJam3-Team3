using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public Transform myTransform { get; set; }
    public Action OnInteract { get; set; }
}

public interface IPickable : IInteractable
{
    public Item slot { get; set; }
    public Action OnPickup {  get; set; }   

}

public interface IChest : IInteractable
{
    public IPickable pickable { get; set; }
}