using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    //classe per tutte le funzioni degli item
    public Transform myTransform { get => transform; set => myTransform = value; }
    public Item slot { get => this; set => slot = value; }

    //public void 
}
