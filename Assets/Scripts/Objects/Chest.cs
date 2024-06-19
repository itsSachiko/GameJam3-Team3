using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IChest

{
    public Transform myTransform { get => transform; set => myTransform = value; }
    public IPickable pickable { get ; set; }
    public Action OnInteract { get; set; }

    private void OnEnable()
    {
        OnInteract += OnInteracted;
    }

    private void OnDisable()
    {
        OnInteract -= OnInteracted;
    }

    private void OnInteracted()
    {
        
    }
}
